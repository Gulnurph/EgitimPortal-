using EGitimPortaliUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EGitimPortaliUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Content")]
	public class ContentController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ContentController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();//istemci oluşturuldu
			var responseMessage = await client.GetAsync("https://localhost:44300/api/Content");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<List<ContentModel>>(json);
				return View(value);
			}
			return View();
		}
	}
}
