using AutoMapper;
using WK.Tech.Domain.Dtos;
using WK.Tech.Domain.Entities;

namespace WK.Tech.Domain.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductDto, Product>()
                .ConstructUsing(p => new Product(
                    p.Name, p.Description, p.Active, p.ProductValue, p.CategoryId, p.Image));

            CreateMap<CategoryDto, Category>()
                .ConstructUsing(c => new Category(c.Name, c.Code));
        }
    }
}