using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManager.API.Models;
using ProductManager.API.Repositories;
using ProductManager.API.Services;
using ProductManager.API.Services.Communication;
using ProductManager.API.Persistence;

namespace ProductManager.API.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
    private readonly IProductCategoryRepository _categoryRepository;
	private readonly IUnitOfWork _unitOfWork;

	public ProductCategoryService(IProductCategoryRepository categoryRepository, IUnitOfWork unitOfWork)
	{
		_categoryRepository = categoryRepository;
		_unitOfWork = unitOfWork;
	}

    

	public async Task<IEnumerable<ProductCategory>> ListAsync()
	{
		return await _categoryRepository.ListAsync();
	}

    public async Task<ProductCategory> FindByIdAsync(int id)
    {
        return await _categoryRepository.FindByIdAsync(id);
    }
	public async Task<ProductCategoryResponse> SaveAsync(ProductCategory category)
	{
		try
		{
			await _categoryRepository.AddAsync(category);
			await _unitOfWork.CompleteAsync();
			
			return new ProductCategoryResponse(category);
		}
		catch (Exception ex)
		{
			// Do some logging stuff
			return new ProductCategoryResponse($"An error occurred when saving the category: {ex.Message}");
		}
     }
    public async Task<ProductCategoryResponse> UpdateAsync(int id, ProductCategory category)
    {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new ProductCategoryResponse("Category not found.");

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new ProductCategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductCategoryResponse($"An error occurred when updating the category: {ex.Message}");
            }
    }
    public async Task<ProductCategoryResponse> DeleteAsync(int id)
    {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new ProductCategoryResponse("Category not found.");

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new ProductCategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductCategoryResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }
    }
}