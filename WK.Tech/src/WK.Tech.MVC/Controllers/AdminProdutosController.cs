using Microsoft.AspNetCore.Mvc;
using WK.Tech.Domain.Dtos;
using WK.Tech.Domain.Interfaces.Services;

namespace WK.Tech.MVC.Controllers
{
    public class AdminProductsController : MainController
    {
        private readonly IProductService _produtctService;

        public AdminProductsController(IProductService produtctService)
        {
            _produtctService = produtctService;
        }

        [HttpGet]
        [Route("admin-produtos")]
        public async Task<IActionResult> Index()
        {
            return View(await _produtctService.GetAll());
        }

        [Route("novo-produto")]
        public async Task<IActionResult> NewProduct()
        {
            return View(await PopularCategories(new ProductDto()));
        }

        [Route("novo-produto")]
        [HttpPost]
        public async Task<IActionResult> NewProduct(ProductDto dto)
        {
            if (!ModelState.IsValid) return View(await PopularCategories(dto));

            await _produtctService.Add(dto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("editar-produto")]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            return View(await PopularCategories(await _produtctService.GetById(id)));
        }

        [HttpPost]
        [Route("editar-produto")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductDto dto)
        {
            var produto = await _produtctService.GetById(id);
            dto.Quantity = produto.Quantity;

            ModelState.Remove("QuantidadeEstoque");
            if (!ModelState.IsValid) return View(await PopularCategories(dto));

            await _produtctService.Update(dto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("admin-categoria")]
        public async Task<IActionResult> Categories()
        {
            return View(await _produtctService.GetAllCategories());
        }

        [Route("nova-categoria")]
        public IActionResult NewCategory()
        {
            return View(new CategoryDto());
        }

        [Route("nova-categoria")]
        [HttpPost]
        public async Task<IActionResult> NewCategory(CategoryDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _produtctService.AddCategory(dto);

            return RedirectToAction("Categories");
        }


        [HttpGet]
        [Route("editar-categoria")]
        public async Task<IActionResult> UpdateCategory(Guid id)
        {
            var categories = await _produtctService.GetByIdCategories(id);
            return View(categories);
        }

        [HttpPost]
        [Route("editar-categoria")]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var category = await _produtctService.GetByIdCategories(id);

           if(category is null) return View(dto);   

            await _produtctService.UpdateCategory(dto);

            return RedirectToAction("Categories");
        }

        [HttpGet]
        [Route("remover-categoria")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categories = await _produtctService.GetByIdCategories(id);
            return View(categories);
        }

        [HttpPost]
        [Route("remover-categoria")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _produtctService.GetByIdCategories(id);

            if (category is null) return RedirectToAction("Categories");

            await _produtctService.DeleteCategory(id);

            return RedirectToAction("Categories");
        }


        [HttpGet]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> UpdateStock(Guid id)
        {
            return View("Estoque", await _produtctService.GetById(id));
        }

        [HttpPost]
        [Route("produtos-atualizar-estoque")]
        public async Task<IActionResult> UpdateStock(Guid id, int quantity)
        {
            if (quantity > 0)
            {
                await _produtctService.ReporStock(id, quantity);
            }
            else
            {
                await _produtctService.DebitStock(id, quantity);
            }

            return View("Index", await _produtctService.GetAll());
        }

        private async Task<ProductDto> PopularCategories(ProductDto produto)
        {
            produto.Categories = await _produtctService.GetAllCategories();
            return produto;
        }
    }
}