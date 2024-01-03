using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IUnitOfWork:IAsyncDisposable
	{
		ITrainingDal TrainingDal { get; }
		IContentDal ContentDal { get; }
		ICategoryDal CategoryDal { get; }
		Task<int> SaveAsync();
	}
}
