using AutoMapper;
using WK.Tech.Core.DomainObjects;
using WK.Tech.Domain.Dtos;
using WK.Tech.Domain.Entities;
using WK.Tech.Domain.Interfaces.Repositories;
using WK.Tech.Domain.Interfaces.Services;

namespace WK.Tech.Domain.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }        

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetAll());
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _productRepository.GetAllCategories());
        }

        public async Task<IEnumerable<ProductDto>> GetByCategory(int code)
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetByCategory(code));
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            return _mapper.Map<ProductDto>(await _productRepository.GetById(id));
        }

        public async Task Add(ProductDto product)
        {
            var produto = _mapper.Map<Product>(product);
            _productRepository.Add(produto);

           await _productRepository.UnitOfWork.Commit();
        }

        public async Task AddCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _productRepository.AddCategory(category);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task Update(ProductDto product)
        {
            var produto = _mapper.Map<Product>(product);
            _productRepository.Update(produto);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _productRepository.UpdateCategory(category);

            await _productRepository.UnitOfWork.Commit();
        }
        
        public async Task<ProductDto> DebitStock(Guid id, int quantity)
        {
            var produto = await _productRepository.GetById(id);

            if (produto == null) throw new DomainException("Falha ao debitar estoque");

            produto.ReplenishStock(quantity);

            _productRepository.Update(produto);

            await _productRepository.UnitOfWork.Commit();

            return _mapper.Map<ProductDto>(await _productRepository.GetById(id));
        }

        public async Task<ProductDto> ReporStock(Guid id, int quantity)
        {

            var produto = await _productRepository.GetById(id);

            if (produto == null) throw new DomainException("Falha ao repor estoque");

            produto.ReplenishStock(quantity);

            _productRepository.Update(produto);

            await _productRepository.UnitOfWork.Commit();

            return _mapper.Map<ProductDto>(await _productRepository.GetById(id));
        }
    }
}
