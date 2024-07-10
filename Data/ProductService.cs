using BlazorWithDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWithDB.Data
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task AddProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                var existingProduct = await _context.Products.FindAsync(product.Product_ID);
                if (existingProduct != null)
                {
                    existingProduct.P_name = product.P_name;
                    existingProduct.Category_ID = product.Category_ID;

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Concurrency error updating product: {ex.Message}");
                throw; 
            }
         
        }



        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }




        public async Task<List<ProductCat>>GetCategoriesAsync()
        {
            return await _context.Product_Categories.ToListAsync();
        }

    }
}
