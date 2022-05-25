using Microsoft.AspNetCore.Mvc;
using WK.Tech.Domain.Interfaces.Services;

namespace WK.Tech.MVC.Controllers
{
    public class VitrineController : Controller
    {
        private readonly IProductService _produtctService;

        public VitrineController(IProductService productService)
        {
            _produtctService = productService;
        }

        [HttpGet]
        [Route("vitrine")]
        public async Task<IActionResult> Index()
        {
            return View(await _produtctService.GetAll());
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            return View(await _produtctService.GetById(id));
        }
    }
}