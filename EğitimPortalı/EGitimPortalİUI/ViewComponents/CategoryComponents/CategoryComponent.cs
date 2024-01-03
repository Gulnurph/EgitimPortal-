
using EGitimPortaliUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using System.Net.Http;

namespace EGitimPortalİUI.ViewComponents
{
    public class CategoryComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IViewComponentResult Invoke()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluşturuldu
            var responseMessage = client.GetAsync("https://localhost:44300/api/Category").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var json =  responseMessage.Content.ReadAsStringAsync().Result;
                var value = JsonConvert.DeserializeObject<List<CategoryMd>>(json);
                return View(value);
            }
            return View();
        }
    }
}