using Microsoft.AspNetCore.Mvc;

namespace ClothingStore.Controllers
{
    public class AuthController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}