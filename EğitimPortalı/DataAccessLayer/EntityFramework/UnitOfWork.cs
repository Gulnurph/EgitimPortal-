using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly Context _context;
		
		private EfTrainingDal _efTrainingDal;
		private EfContentDal _efcontentDal;
		private EfCategoryDal _efcategoryDal;
		public UnitOfWork(Context context)
		{
			_context = context;
		}

		public ITrainingDal TrainingDal =>_efTrainingDal ?? new EfTrainingDal(_context);

		public IContentDal ContentDal => _efcontentDal ?? new EfContentDal(_context);

        public ICategoryDal CategoryDal => _efcategoryDal ?? new EfCategoryDal(_context);

        public async ValueTask DisposeAsync()
		{
		 await _context.DisposeAsync();
		}

		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}
	}
}
