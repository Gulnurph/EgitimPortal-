using BusinessLayer.Abstract;
using EGitimPortaliUI.Areas.Admin.Models;
using EGitimPortaliUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;


namespace EGitimPortalİUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluşturuldu
            var responseMessage = await client.GetAsync("https://localhost:44300/api/Training");
            if (responseMessage.IsSuccessStatusCode)
            {
                var json = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<TrainingMd>>(json);
                return View(value);
            }
            return View();
        }
        
        //[HttpGet]
        //public async Task<IActionResult> CategoryList()
        //{
        //    var client = _httpClientFactory.CreateClient();//istemci oluşturuldu
        //    var responseMessage = await client.GetAsync("https://localhost:44300/api/Category");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var json = await responseMessage.Content.ReadAsStringAsync();
        //        var value = JsonConvert.DeserializeObject<List<CategoryMd>>(json);
        //        return View(value);
        //    }
        //    return View();
        //}


        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}