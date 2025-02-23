using Dapper;
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


        public SqlConnection ConnectionString()
        {
            return new SqlConnection( _configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
