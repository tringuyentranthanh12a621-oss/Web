using Lab08.Repositories.Interfaces;
using Lab08.Services.Interfaces;
using Lab08.Models;

namespace Lab08.Services.Implementations
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _repository;

        // Inject Repository vào Service
        public CarModelService(ICarModelRepository repository)
        {
            _repository = repository;
        }

        public List<CarModelVm> GetCarModels()
        {
            // Repository đã trả về List<CarModelVm> nên chỉ cần gọi lại
            return _repository.GetAll();
        }

        public CarModelVm? GetCarModelById(int id)
        {
            // Repository đã trả về CarModelVm? nên chỉ cần gọi lại
            return _repository.GetById(id);
        }

        public void CreateCarModel(CarModelVm carVm)
        {
            // Repository mong đợi CarModelVm (như đã fix ở bước trước)
            _repository.Add(carVm);
        }

        public void UpdateCarModel(CarModelVm carVm)
        {
            _repository.Update(carVm);
        }

        public void DeleteCarModel(int id)
        {
            _repository.Delete(id);
        }
    }
}