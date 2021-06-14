using System.Collections.Generic;
using System.Linq;
using Book.Data;
using Book.Dtos;

namespace Book.Services.Categoryy
{
    public interface ICategoryRepository
    {
        void AddCategory(AddCategoryDto dto);
        List<Category> GetAll();
        void Delete(long Id);
        Category GetById(long Id);
        void Save();

    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataBaseContext _context;

        public CategoryRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void AddCategory(AddCategoryDto dto)
        {
            _context.Categories.Add(new Category()
            {
                Title = dto.Title
            });
        }

        public void Delete(long Id)
        {
            _context.Categories.Remove(GetById(Id));
        }

        public List<Category> GetAll()
        {
            return _context.Categories.OrderByDescending(p=>p.CategoryId).ToList();
        }

        public Category GetById(long Id)
        {
            return _context.Categories.Find(Id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}