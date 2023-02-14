
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManager.API.Models;
using ProductManager.API.Services.Communication;

namespace ProductManager.API.Services
{
    public interface IProductCategoryService
    {
    Task<ProductCategory> FindByIdAsync(int id);
    Task<IEnumerable<ProductCategory>> ListAsync();
	Task<ProductCategoryResponse> SaveAsync(ProductCategory category);
	Task<ProductCategoryResponse> UpdateAsync(int id, ProductCategory category);
    Task<ProductCategoryResponse> DeleteAsync(int id);
    }

 }

