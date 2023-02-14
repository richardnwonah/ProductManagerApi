using Microsoft.AspNetCore.Mvc;
using ProductManager.API.Services;
using ProductManager.API.Models;
using ProductManager.API.Extensions;
using ProductManager.API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ProductManager.API.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class ProductCategoriesController : Controller
    {
         private readonly IProductCategoryService _categoryService;
         private readonly IMapper _mapper;
        
        public ProductCategoriesController(IProductCategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService; 
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ProductCategoryResource> GetById(int id)
        {
            var Category = await _categoryService.FindByIdAsync(id);
            var resource = _mapper.Map<ProductCategory,  ProductCategoryResource> (Category);
            return resource;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryResource>> (categories);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveProductCategoryResource, ProductCategory>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var ProductcategoryResource = _mapper.Map<ProductCategory, ProductCategoryResource>(result.ProductCategory);
            return Ok(ProductcategoryResource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveProductCategoryResource, ProductCategory>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var ProductcategoryResource = _mapper.Map<ProductCategory, ProductCategoryResource>(result.ProductCategory);
            return Ok(ProductcategoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var ProductcategoryResource = _mapper.Map<ProductCategory, ProductCategoryResource>(result.ProductCategory);
            return Ok(ProductcategoryResource);
        }
    }
}