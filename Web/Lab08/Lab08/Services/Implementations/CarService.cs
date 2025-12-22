using Lab08.Models;
using Lab08.Repositories.Interface;
using Lab08.Services.Interfaces;

namespace Lab08.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;
        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<Car> GetAllCars()
        {
            return _repository.GetAll();
        }
        public Car? GetCarById(int id)
        {
            return _repository.GetById(id);
        }
        public void CreateCar(Car car)
        {
            _repository.Add(car);
        }
        public void UpdateCar(Car car)
        {
            _repository.Update(car);
        }
        public void DeleteCar(int id)
        {
            _repository.Delete(id);
        }
    }
}
