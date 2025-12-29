using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IWebHostEnvironment _env; // Để lấy đường dẫn folder

        public ProductService(IProductRepository repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        public IEnumerable<Product> GetAll() => _repository.GetAll();
        public Product GetById(int id) => _repository.GetById(id);

        public void CreateProduct(CreateProductDto dto)
        {
            string imagePath = null;
            if (dto.Image != null)
            {
                // Logic lưu file vào wwwroot/images
                string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                string uniqueName = Guid.NewGuid().ToString() + "_" + dto.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    dto.Image.CopyTo(fileStream);
                }
                imagePath = "/images/" + uniqueName;
            }

            // Map DTO sang Model
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                ImageUrl = imagePath
            };

            _repository.Add(product);
        }

        public void DeleteProduct(int id) => _repository.Delete(id);
        public void UpdateProduct(int id, CreateProductDto dto)
        {
            var existingProduct = _repository.GetById(id);
            if (existingProduct == null) return;

            // Cập nhật thông tin cơ bản
            existingProduct.Name = dto.Name;
            existingProduct.Price = dto.Price;
            existingProduct.CategoryId = dto.CategoryId;

            // Nếu có up ảnh mới thì xử lý, không thì giữ ảnh cũ
            if (dto.Image != null)
            {
                // ... (Copy lại logic lưu ảnh từ hàm CreateProduct) ...
                // Lưu ý: Code chuẩn nên tách logic lưu ảnh ra hàm riêng để tái sử dụng
                string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                string uniqueName = Guid.NewGuid().ToString() + "_" + dto.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    dto.Image.CopyTo(fileStream);
                }
                existingProduct.ImageUrl = "/images/" + uniqueName;
            }

            _repository.Update(existingProduct);
        }
    }
}