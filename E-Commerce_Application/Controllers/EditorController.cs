using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Application.Controllers
{
	public class EditorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
