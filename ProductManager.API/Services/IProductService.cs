using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManager.API.Models;
using ProductManager.API.Services.Communication;

namespace ProductManager.API.Services
{
    public interface IProductService
    {
        Task<Product> FindByIdAsync(int id);
        Task<IEnumerable<Product>> ListAsync();
         Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> UpdateAsync(int id, Product product);
        Task<ProductResponse> DeleteAsync(int id);
    }
}