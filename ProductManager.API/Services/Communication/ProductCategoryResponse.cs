using ProductManager.API.Models;

namespace ProductManager.API.Services.Communication
{
    public class ProductCategoryResponse : BaseResponse
    {
        public ProductCategory ProductCategory { get; private set; }

        private ProductCategoryResponse(bool success, string message, ProductCategory category) : base(success, message)
        {
            ProductCategory = category;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public ProductCategoryResponse(ProductCategory category) : this(true, string.Empty, category)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProductCategoryResponse(string message) : this(false, message, null)
        { }
    }
}