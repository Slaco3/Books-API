using Microsoft.AspNetCore.Mvc;

namespace TestAPI0924.Controllers
{
	public class BookController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
