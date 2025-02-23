using Dapper_Sample_Project.DTOs.RequestDTOs;
using ProductAPI.Entities;

namespace Dapper_Sample_Project.IRepository
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<UserRequestDTO> AddUser(UserRequestDTO user);
        Task<string> DeleteUser(int Id);
        Task<string> UpdateUser(User user);
    }
}
