using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Data;
using Book.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Book.Services.Categoryy
{
    public interface ICategoryRepository
    {
        Task AddCategory(AddCategoryDto dto);
        Task<List<Category>> GetAll();
        Task Delete(long Id);
        Task<Category> GetById(long Id);
        Task Save();

    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataBaseContext _context;

        public CategoryRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task AddCategory(AddCategoryDto dto)
        {
            await _context.Categories.AddAsync(new Category()
            {
                Title = dto.Title
            });
        }

        public async Task Delete(long Id)
        {
            _context.Categories.Remove(await GetById(Id));
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.OrderByDescending(p=>p.CategoryId).ToListAsync();
        }

        public async Task<Category> GetById(long Id)
        {
            return await _context.Categories.FindAsync(Id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}