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
	public class ContentManager : IContentServices
	{
		private IUnitOfWork _unitOfWork;

		public ContentManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void AddAsync(Content entity)
		{
			_unitOfWork.ContentDal.AddAsync(entity);
			_unitOfWork.SaveAsync();
			
		}

		public void DeleteAsync(Content entity)
		{
			_unitOfWork.ContentDal.DeleteAsync(entity);
		}

		public IList<Content> GetAllAsync()
		{
		 var result=_unitOfWork.ContentDal.GetAllAsync();
			return result.ToList();
		}

		public Content GetById(int id)
		{
			var result=_unitOfWork.ContentDal.GetById(id);
			return result;
		}

		public void UpdateAsync(Content entity)
		{
			_unitOfWork.ContentDal.UpdateAsync(entity);
			_unitOfWork.SaveAsync();
		}
	}
}
