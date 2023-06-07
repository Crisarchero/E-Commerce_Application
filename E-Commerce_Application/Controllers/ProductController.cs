using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Application.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
