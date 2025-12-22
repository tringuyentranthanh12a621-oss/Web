using Lab08.Models;


namespace Lab08.Repositories.Interfaces
{
    public interface ICarModelRepository
    {
        List<CarModelVm> GetAll();
        CarModelVm? GetById(int id);
        void Add(CarModelVm carModel);
        void Update(CarModelVm carModel);
        void Delete(int id);
    }
}