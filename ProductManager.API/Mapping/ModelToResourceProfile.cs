using AutoMapper;
using ProductManager.API.Extensions;
using ProductManager.API.Models;
using ProductManager.API.Resources;

namespace ProductManager.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<ProductCategory, ProductCategoryResource>();
             CreateMap<Business, BusinessResource>();

               CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}

