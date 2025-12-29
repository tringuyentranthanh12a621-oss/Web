using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void CreateProduct(CreateProductDto dto); // Logic xử lý ảnh sẽ nằm ở đây
        void DeleteProduct(int id);
        // Thêm dòng này vào Interface
        void UpdateProduct(int id, CreateProductDto dto);
    }
}