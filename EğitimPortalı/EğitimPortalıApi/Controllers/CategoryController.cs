using BusinessLayer.Abstract;
using EntityLayer.Dto;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EğitimPortalıApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
          
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _categoryServices.GetAllAsync();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createTraining)
        {

            Category training = new Category()
            {
             CategoryName= createTraining.CategoryName,
            };
          _categoryServices.AddAsync(training);

            return Ok("Kategori Eklendi");

        }
        [HttpPut]
        public async Task<IActionResult> CategorygUpdate(CategoryUpdateDto updatecategory)
        {
            Category category = new Category()
            {

               CategoryID=updatecategory.CategoryID,
               CategoryName=updatecategory.CategoryName,
               


            };
           _categoryServices.UpdateAsync(category);
            return Ok("Güncelleme yapıldı");
        }
		[HttpGet("{id}")]
		public IActionResult GetCategory(int id)
		{
			var value = _categoryServices.GetById(id);
			return Ok(value);
		}

		[HttpDelete("{id}")]
        public IActionResult CategoryDelete(int id)
        {
            var value = _categoryServices.GetById(id);
            _categoryServices.DeleteAsync(value);
            return Ok("Silindi");

        }
        //[HttpGet("TrainingWithCategory")]
        //public IActionResult TrainingWithContent()
        //{
        //    var db = new Context();
        //    var values = db.Category.Include(x => x.Trainings).Select(y => new TrainingWithCategory()
        //    {
        //       CategoryID=y.CategoryID,
        //       CategoryName=y.CategoryName,
        //       //TrainingName=y.Training.Title
        //    });

        //    return Ok(values.ToList());
        //}

    }
}
