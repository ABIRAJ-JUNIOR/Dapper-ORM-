using ProductAPI.Entities;

namespace Dapper_Sample_Project.DTOs.RequestDTOs
{
    public class UserRequestDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; }
    }
}
