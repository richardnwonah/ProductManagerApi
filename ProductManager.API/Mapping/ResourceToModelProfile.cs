using AutoMapper;
using ProductManager.API.Models;
using ProductManager.API.Resources;

namespace ProductManager.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveProductCategoryResource, ProductCategory>();
             CreateMap<SaveBusinessResource, Business>();
             CreateMap<SaveProductResource, Product>();
        }
    }
}