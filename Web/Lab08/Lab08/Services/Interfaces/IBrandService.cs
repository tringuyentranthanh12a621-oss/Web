using Lab08.Models;

namespace Lab08.Services.Interfaces
{
    public interface IBrandService
    {
        List<Brand> GetAllBrands();
        Brand? GetBrandById(int id);
        void CreateBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(int id);
    }
}
