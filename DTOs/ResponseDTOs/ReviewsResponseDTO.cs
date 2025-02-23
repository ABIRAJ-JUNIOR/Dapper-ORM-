using ProductAPI.Entities;

namespace Dapper_Sample_Project.DTOs.ResponseDTOs
{
    public class ReviewsResponseDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
