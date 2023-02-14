using System.ComponentModel.DataAnnotations;

namespace ProductManager.API.Resources
{
      public class SaveProductCategoryResource
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
         public int BusinessId { get; set; }
    
    }
}