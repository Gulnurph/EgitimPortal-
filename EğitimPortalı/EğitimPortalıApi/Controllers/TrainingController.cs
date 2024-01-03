using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EğitimPortalıApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TrainingController : ControllerBase
	{
		private readonly ITrainingServices _trainingServices;

		public TrainingController(ITrainingServices trainingServices)
		{
			_trainingServices = trainingServices;
		}

		[HttpGet]
		public IActionResult TrainingList()
		{
			var value = _trainingServices.GetAllAsync();
			return Ok(value);
		}
		[HttpGet("{id}")]
		public IActionResult GetTraining(int id)
		{
			var value = _trainingServices.GetById(id);
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateTraining(CreateTrainingDto createTraining)
		{

			Training training = new Training()
			{
				CategoryId = createTraining.CategoryId,
				CostPerDay = createTraining.CostPerDay,
				Duration = createTraining.Duration,
				Quota = createTraining.Quota,
				Title = createTraining.Title,
				Instructor = createTraining.Instructor,
				ImgUrl=createTraining.ImgUrl,
			};
	    _trainingServices.AddAsync(training);

			return Ok("Eğitim Eklendi");

		}
		[HttpPut]
		public async Task<IActionResult> TrainingUpdate(UpdateTrainingDto updateTraining)
		{
			Training training = new Training()
			{
				Title= updateTraining.Title,
				CategoryId= updateTraining.CategoryId,
				CostPerDay= updateTraining.CostPerDay,
				Duration = updateTraining.Duration,
				Quota= updateTraining.Quota,
				Id= updateTraining.Id,
				ImgUrl= updateTraining.ImgUrl,
			Instructor= updateTraining.Instructor,
				


			};
			_trainingServices.UpdateAsync(training);
			return Ok("Güncelleme yapıldı");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> TrainingDelete(int id)
		{
		  var value= _trainingServices.GetById(id);
		_trainingServices.DeleteAsync(value);
			return Ok("Silindi");
		
		}
		[HttpGet("TrainingWithContent")]
		public IActionResult TrainingWithContent()
		{
			var db = new Context();
			var values = db.Content.Include(x => x.Training).Select(y => new TrainingWithContentDto()
			{
				ContentType = y.ContentType,
				ContentUrl = y.ContentUrl,
				TrainingId=y.TrainingId,
				Id=y.Id,
				TrainingName=y.Training.Title,
				CategoryName=y.Training.Categorys.CategoryName,
			});

			return Ok(values.ToList());
		}
	}
}
