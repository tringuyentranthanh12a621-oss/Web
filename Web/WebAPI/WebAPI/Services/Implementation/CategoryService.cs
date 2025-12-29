using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = _repository.GetAll();

            // Map từ Model sang DTO
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        public CategoryDto GetById(int id)
        {
            var category = _repository.GetById(id);
            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public void Add(CategoryDto dto)
        {
            // Map từ DTO sang Model để lưu xuống DB
            var category = new Category
            {
                Name = dto.Name
            };
            _repository.Add(category);
        }

        public void Update(int id, CategoryDto dto)
        {
            var existingCategory = _repository.GetById(id);
            if (existingCategory != null)
            {
                existingCategory.Name = dto.Name;
                _repository.Update(existingCategory);
            }
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}