using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EğitimPortalıApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContentController : ControllerBase
	{
		private IContentServices _contentServices;



		public ContentController(IContentServices contentServices)
		{
			_contentServices = contentServices;

		}
		[HttpGet]
		public IActionResult GetContent()
		{
			var value = _contentServices.GetAllAsync();
			return Ok(value);
		}

		[HttpPost]
		public  async Task<IActionResult> AddContent(CreateContentDto content)
		{
			Content content1 = new Content()
			{
				ContentType = content.ContentType,
				ContentUrl = content.ContentUrl,
				TrainingId = content.TrainingId,

			};
			_contentServices.AddAsync(content1);
			return Ok("Content Eklendi");
		}
		[HttpPut]
		public async Task<IActionResult> ContentUpdate(UpdateContentDto updateTraining)
		{
			Content training = new Content()
			{
				ContentType = updateTraining.ContentType,
				ContentUrl = updateTraining.ContentUrl,
				TrainingId = updateTraining.TrainingId,
				Id = updateTraining.Id



			};
			_contentServices.UpdateAsync(training);
			return Ok("Güncelleme Yapıldı");

		}
	}
}
