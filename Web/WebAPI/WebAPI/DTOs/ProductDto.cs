namespace WebAPI.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; } // Flattened data
        public string ImagePath { get; set; }
    }
}