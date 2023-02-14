

using System.ComponentModel.DataAnnotations;

namespace ProductManager.API.Resources
{
    public class LoginResource
    {
        [Required(ErrorMessage = "Username is required")]      
         public string Email { get; set; }

       [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "For password, Minimum eight characters, at least one uppercase letter, one lowercase letter, " +
            "one number and one special character")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}