using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManager.API.Models;

namespace ProductManager.API.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> ListAsync();
        Task AddAsync(ProductCategory category);
        Task<ProductCategory> FindByIdAsync(int id);
	    void Update(ProductCategory category);
        void Remove(ProductCategory category);
    }
}