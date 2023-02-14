using System.Collections.Generic;

namespace ProductManager.API.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>(); 
        public int BusinessId { get; set; }
        public Business Business {get; set; }
    }
}