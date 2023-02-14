

namespace ProductManager.API.Resources
{
    public class SaveProductResource
    {
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int CategoryId {get;set;}
    }
}