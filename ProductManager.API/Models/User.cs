using System.Collections.Generic;

namespace ProductManager.API.Models
{
    public class User
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public List<Business> Businesses { get; set; }
    
    }
}