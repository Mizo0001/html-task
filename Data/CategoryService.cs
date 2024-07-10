using BlazorWithDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWithDB.Data
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductCat>> GetCategoryAsync()
        {
            return await _context.Product_Categories.ToListAsync();
        }
    }
}
