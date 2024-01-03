using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class TrainingManager : ITrainingServices
	{
		private IUnitOfWork _unitOfWork;

		public TrainingManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void AddAsync(Training entity)
		{
			_unitOfWork.TrainingDal.AddAsync(entity);
			_unitOfWork.SaveAsync();

		}

		public void DeleteAsync(Training entity)
		{
			_unitOfWork.TrainingDal.DeleteAsync(entity);
		}

		public IList<Training> GetAllAsync()
		{
			var result=_unitOfWork.TrainingDal.GetAllAsync();
			return result.ToList();
		}

		public Training GetById(int id)
		{
			var result=_unitOfWork.TrainingDal.GetById(id);
			return result;
		}

		public void UpdateAsync(Training entity)
		{
			_unitOfWork.TrainingDal.UpdateAsync(entity);
		}
	}
}
