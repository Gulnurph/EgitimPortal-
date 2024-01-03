using EGitimPortaliUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace EGitimPortaliUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Training")]
	public class TrainingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TrainingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();//istemci oluşturuldu
            var responseMessage = await client.GetAsync("https://localhost:44300/api/Training");
            if(responseMessage.IsSuccessStatusCode)
            {
                var json=await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<TrainingModel>>(json);
                return View(value);
            }
            return View();
        }
		[Route("AddTraining")]
		[HttpGet]
        public async Task<IActionResult> AddTraining()
        {
            return View();
        }
		[Route("AddTraining")]
		[HttpPost]
		public async Task<IActionResult> AddTraining(TrainingModel trainingModel)
		{
            var client= _httpClientFactory.CreateClient();
            var json=JsonConvert.SerializeObject(trainingModel);
            StringContent stringContent=new StringContent(json,Encoding.UTF8, "application/json");
            var responsmessage = await client.PostAsync("https://localhost:44300/api/Training", stringContent);
            if(responsmessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
				return View();
			
			
		}
		[Route("DeleteTraining")]
       
		public async Task<IActionResult> DeleteTraining(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responmessage = await client.DeleteAsync($"https://localhost:44300/api/Training/{id}");
			if (responmessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}
        [Route("UpdateTraining")]
        [HttpGet]
        public async Task<IActionResult> UpdateTraining(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44300/api/Training/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var json=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<UpdateTrainingModel>(json);
                return View(value);
            }
            return View();
        }
		[Route("UpdateTraining")]
		[HttpPost]
        public async Task<IActionResult> UpdateTraining(UpdateTrainingModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var json=JsonConvert.SerializeObject(model);
			StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
			var responsmessage = await client.PutAsync("https://localhost:44300/api/Training", stringContent);
			if (responsmessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();

		}

	}
}
