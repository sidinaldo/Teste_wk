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
        public async Task<IActionResult> NewProduct(ProductDto produtoViewModel)
        {
            if (!ModelState.IsValid) return View(await PopularCategories(produtoViewModel));

            await _produtctService.Add(produtoViewModel);

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
        public async Task<IActionResult> UpdateProduct(Guid id, ProductDto produtoViewModel)
        {
            var produto = await _produtctService.GetById(id);
            produtoViewModel.Quantity = produto.Quantity;

            ModelState.Remove("QuantidadeEstoque");
            if (!ModelState.IsValid) return View(await PopularCategories(produtoViewModel));

            await _produtctService.Update(produtoViewModel);

            return RedirectToAction("Index");
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