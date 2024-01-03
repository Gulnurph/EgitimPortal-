using EGitimPortaliUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EGitimPortaliUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Category")]
	public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluşturuldu
            var responseMessage = await client.GetAsync("https://localhost:44300/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var json = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<CategoryModel>>(json);
                return View(value);
            }
            return View();
        }
		[Route("AddCategory")]
		[HttpGet]
		public async Task<IActionResult> AddCategory()
		{
			return View();
		}
		[Route("AddCategory")]
		[HttpPost]
		public async Task<IActionResult> AddCategory(CategoryModel trainingModel)
		{
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(trainingModel);
			StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
			var responsmessage = await client.PostAsync("https://localhost:44300/api/Category", stringContent);
			if (responsmessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

			
		}
		[Route("DeleteCategory")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responmessage = await client.DeleteAsync($"https://localhost:44300/api/Category{id}");
			if (responmessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}
		[Route("UpdateCategory")]
		[HttpGet]
		public async Task<IActionResult> UpdateCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44300/api/Category/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var json = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateCategoryModel>(json);
				return View(value);
			}
			return View();
		}
		[Route("UpdateCategory")]
		[HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryModel model)
		{
			var client = _httpClientFactory.CreateClient();
			var json = JsonConvert.SerializeObject(model);
			StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
			var responsmessage = await client.PutAsync("https://localhost:44300/api/Category", stringContent);
			if (responsmessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}
	}
}
