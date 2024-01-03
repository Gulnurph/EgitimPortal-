using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfTrainingDal:GenericRepository<Training>, ITrainingDal
	{

		public EfTrainingDal(Context context) : base(context)
		{
		}
	}
}
