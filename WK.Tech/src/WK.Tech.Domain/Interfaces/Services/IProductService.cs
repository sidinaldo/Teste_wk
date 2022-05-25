using WK.Tech.Domain.Dtos;

namespace WK.Tech.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> GetById(Guid id);
        Task<IEnumerable<ProductDto>> GetByCategory(int code);
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        Task Add(ProductDto product);
        Task Update(ProductDto product);
        Task AddCategory(CategoryDto category);
        Task UpdateCategory(CategoryDto category);
        Task<ProductDto> DebitStock(Guid id, int quantity);
        Task<ProductDto> ReporStock(Guid id, int quantity);
    }
}
