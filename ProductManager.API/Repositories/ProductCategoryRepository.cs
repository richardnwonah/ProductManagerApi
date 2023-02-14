using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManager.API.Models;
using ProductManager.API.Repositories;
using ProductManager.API.Data;

namespace ProductManager.API.Repositories
{
    public class ProductCategoryRepository : BaseRepository, IProductCategoryRepository
    {
        public ProductCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductCategory>> ListAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }
        public async Task AddAsync(ProductCategory category)
        {
            await _context.ProductCategories.AddAsync(category);
        }
        public async Task<ProductCategory> FindByIdAsync(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        public void Update(ProductCategory category)
        {
            _context.ProductCategories.Update(category);
        }
        public void Remove(ProductCategory category)
        {
            _context.ProductCategories.Remove(category);
        }
    }
}