using Lab08.Data;
using Lab08.Models;
using Lab08.Repositories.Interface;
using Lab08.Repositories.Interfaces; // Lưu ý namespace Interface của bạn (số ít hay số nhiều)

namespace Lab08.Repositories.Implementations
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            // --- SỬA LỖI TẠI ĐÂY ---
            _context = context;
        }

        public List<Car> GetAll()
        {
            // Bây giờ _context đã có dữ liệu, dòng này sẽ chạy thành công
            return _context.Cars.ToList();
        }

        public Car? GetById(int id)
        {
            return _context.Cars.Find(id);
        }

        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Update(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
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