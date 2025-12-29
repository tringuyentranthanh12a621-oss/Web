using WebAPI.Data;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore; // Cần dòng này để dùng .Include()

namespace WebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            // Include(p => p.Category) giúp join bảng để lấy thông tin Category
            return _context.Products.Include(p => p.Category).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products
                           .Include(p => p.Category)
                           .FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}