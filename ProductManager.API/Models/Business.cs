using System.Collections.Generic;

namespace ProductManager.API.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User User {get; set; }
        public IList<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>(); 
    
    } 
}