using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddAsync(Category entity)
        {
            _unitOfWork.CategoryDal.AddAsync(entity);
            _unitOfWork.SaveAsync();
        }

        public void DeleteAsync(Category entity)
        {
            _unitOfWork.CategoryDal.DeleteAsync(entity);
        }

        public IList<Category> GetAllAsync()
        {
            var result = _unitOfWork.CategoryDal.GetAllAsync();
            return result.ToList();
        }

        public Category GetById(int id)
        {
            var result = _unitOfWork.CategoryDal.GetById(id);
            return result;
        }

        public void UpdateAsync(Category entity)
        {
            _unitOfWork.CategoryDal.UpdateAsync(entity);
        }
    }
}
