using Microsoft.AspNetCore.Http; // Required for IFormFile

namespace WebAPI.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public IFormFile? Image { get; set; } // Handles file upload
    }
}