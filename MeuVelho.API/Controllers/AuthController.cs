using Microsoft.AspNetCore.Mvc;

namespace MeuVelho.API.Controllers
{
    public class Auth : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}