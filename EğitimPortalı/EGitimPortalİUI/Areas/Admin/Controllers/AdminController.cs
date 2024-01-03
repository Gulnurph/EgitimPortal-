using Microsoft.AspNetCore.Mvc;

namespace EGitimPortaliUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin")]
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
