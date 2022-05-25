using WK.Tech.Core;
using WK.Tech.Domain.Entities;

namespace WK.Tech.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<IEnumerable<Product>> GetByCategory(int code);
        Task<IEnumerable<Category>> GetAllCategories();
        void Add(Product product);
        void Update(Product product);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
    }
}
