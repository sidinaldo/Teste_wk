using Microsoft.AspNetCore.Mvc;
using WK.Tech.MVC.ViewModels;

namespace WK.Tech.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponseErrors(ResponseResult resposta)
        {
            if (resposta != null && resposta.Errors.Mensagens.Any())
            {
                foreach (var mensagem in resposta.Errors.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }
    }
}
