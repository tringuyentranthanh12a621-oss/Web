using Lab08.Models;
using Lab08.Repositories.Interfaces;
using Lab08.Services.Interfaces;

namespace Lab08.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public List<Brand> GetAllBrands()
        {
            return _brandRepository.GetAll();
        }
        public Brand? GetBrandById(int id)
        {
            return _brandRepository.GetById(id);
        }
        public void CreateBrand(Brand brand)
        {
            _brandRepository.Add(brand);
        }
        public void UpdateBrand(Brand brand)
        {
            _brandRepository.Update(brand);
        }
        public void DeleteBrand(int id)
        {
            _brandRepository.Delete(id);
        }
    }
}
