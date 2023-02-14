using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManager.API.Models;
using ProductManager.API.Repositories;
using ProductManager.API.Services.Communication;
using ProductManager.API.Persistence;

namespace ProductManager.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
    
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }
        public async Task<Product> FindByIdAsync(int id)
        {
            return await _productRepository.FindByIdAsync(id);
        }
        public async Task<ProductResponse> SaveAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();
                
                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductResponse($"An error occurred when saving the product: {ex.Message}");
            }
        }
         public async Task<ProductResponse> UpdateAsync(int id, Product product)
        {
                var existingProduct = await _productRepository.FindByIdAsync(id);

                if (existingProduct == null)
                    return new ProductResponse("Product not found.");

                existingProduct.Name = product.Name;
                existingProduct.QuantityInPackage = product.QuantityInPackage;
                existingProduct.UnitOfMeasurement = product.UnitOfMeasurement;
                existingProduct.CategoryId = product.CategoryId;

                try
                {
                    _productRepository.Update(existingProduct);
                    await _unitOfWork.CompleteAsync();

                    return new ProductResponse(existingProduct);
                }
                catch (Exception ex)
                {
                    // Do some logging stuff
                    return new ProductResponse($"An error occurred when updating the product: {ex.Message}");
                }
            }

            public async Task<ProductResponse> DeleteAsync(int id)
            {
            var existingProduct = await _productRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new ProductResponse("Product not found.");

            try
            {
                _productRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProductResponse($"An error occurred when deleting the product: {ex.Message}");
            }
        }
    }
}