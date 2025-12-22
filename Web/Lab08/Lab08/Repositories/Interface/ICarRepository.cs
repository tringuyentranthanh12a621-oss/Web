using Lab08.Models;
namespace Lab08.Repositories.Interface
{
    public interface ICarRepository
    {
        List<Car> GetAll();
        Car? GetById(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(int id);
    }
}
