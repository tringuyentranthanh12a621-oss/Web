using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) => _context = context;

        public IEnumerable<Category> GetAll() => _context.Categories.ToList();
        public Category GetById(int id) => _context.Categories.Find(id);
        public void Add(Category category) { _context.Categories.Add(category); _context.SaveChanges(); }
        public void Update(Category category) { _context.Categories.Update(category); _context.SaveChanges(); }
        public void Delete(int id)
        {
            var entity = _context.Categories.Find(id);
            if (entity != null) { _context.Categories.Remove(entity); _context.SaveChanges(); }
        }
    }
}