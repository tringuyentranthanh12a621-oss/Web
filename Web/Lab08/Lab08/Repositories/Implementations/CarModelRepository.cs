using Lab08.Data;
using Lab08.Models;
using Lab08.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab08.Repositories.Implementations
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly ApplicationDbContext _context;

        public CarModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CarModelVm> GetAll()
        {
            return _context.Cars
                .Include(c => c.Brand)
                .Select(c => new CarModelVm
                {
                    Id = c.Id,
                    CarModelName = c.Name,
                    BrandId = c.BrandId,
                    BrandName = c.Brand.Name
                })
                .ToList();
        }

        public CarModelVm? GetById(int id)
        {
            var car = _context.Cars
                .Include(c => c.Brand)
                .FirstOrDefault(c => c.Id == id);

            if (car == null) return null;

            return new CarModelVm
            {
                Id = car.Id,
                CarModelName = car.Name,
                BrandId = car.BrandId,
                BrandName = car.Brand.Name
            };
        }

        // --- SỬA LỖI Ở ĐÂY ---
        // Thay đổi tham số từ 'Car' thành 'CarModelVm' để khớp với Interface
        public void Add(CarModelVm carVm)
        {
            // 1. Tạo mới Entity Car từ dữ liệu ViewModel
            var car = new Car
            {
                Name = carVm.CarModelName, // Map từ ViewModel sang Entity
                BrandId = carVm.BrandId
            };

            // 2. Lưu Entity vào Database
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Update(CarModelVm carVm)
        {
            // 1. Tìm Entity cũ trong Database
            var car = _context.Cars.Find(carVm.Id);

            if (car != null)
            {
                // 2. Cập nhật dữ liệu mới từ ViewModel
                car.Name = carVm.CarModelName;
                car.BrandId = carVm.BrandId;

                // 3. Lưu thay đổi
                _context.Cars.Update(car);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }
    }
}