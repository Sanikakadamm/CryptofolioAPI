using Microsoft.AspNetCore.Mvc;

namespace CryptoFolioAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
