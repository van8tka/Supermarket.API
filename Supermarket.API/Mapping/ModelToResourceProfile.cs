using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;

namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile:Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>().ForMember(x => x.UnitOfMeasurement,
                o => o.MapFrom(x => x.UnitOfMeasuerment.ToDescriptionString()));
        }
    }
}