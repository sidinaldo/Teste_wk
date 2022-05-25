using AutoMapper;
using WK.Tech.Domain.Dtos;
using WK.Tech.Domain.Entities;

namespace WK.Tech.Domain.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}