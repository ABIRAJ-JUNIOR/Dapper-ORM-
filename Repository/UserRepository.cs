using Dapper;
using Dapper_Sample_Project.DTOs.RequestDTOs;
using Dapper_Sample_Project.DTOs.ResponseDTOs;
using Dapper_Sample_Project.IRepository;
using Microsoft.Data.SqlClient;
using ProductAPI.Entities;

namespace Dapper_Sample_Project.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            using var connection = ConnectionString();
            var users = await connection.QueryAsync<User>("SELECT * FROM Users");
            return users.ToList();
        }

        public async Task<User> GetUser(int id)
        {
            using var connection = ConnectionString();
            var user = await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users WHERE Id = @Id", new {Id = id});
            return user!;
        }

        public async Task<UserRequestDTO> AddUser(UserRequestDTO user)
        {
            using var connection = ConnectionString();
            var result = await connection.ExecuteAsync("INSERT INTO Users (UserName, Email, Password, Role) VALUES (@UserName, @Email, @Password, @Role)", user);
            return user;
        }

        public async Task<string> UpdateUser(User user)
        {
            using var connection = ConnectionString();
            var result = await connection.ExecuteAsync("UPDATE Users SET UserName = @UserName, Email = @Email, Password = @Password, Role = @Role WHERE Id = @Id", user);
            return "User Updated Successfully";
        }

        public async Task<string> DeleteUser(int id)
        {
            using var connection = ConnectionString();  
            var result = await connection.ExecuteAsync("DELETE FROM Users WHERE Id = @Id", new { Id = id });
            return "User Deleted Successfully";
        }

        public async Task<ICollection<ReviewsResponseDTO>> GetUserReviews()
        {
            using var connection = ConnectionString();
            var query = @"
            SELECT R.Id, R.ProductId, R.Rating, R.Comment, R.ReviewDate, 
                R.UserId, U.UserName 
            FROM Review R
            LEFT JOIN Users U ON R.UserId = U.Id";

            var reviews = await connection.QueryAsync<ReviewsResponseDTO>(query);
            return reviews.ToList();
        }

        public SqlConnection ConnectionString()
        {
            return new SqlConnection( _configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
