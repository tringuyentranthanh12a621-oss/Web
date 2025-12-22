using Lab08.Models;

namespace Lab08.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        List<Brand> GetAll();
        Brand? GetById(int id);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(int id);
    }
}