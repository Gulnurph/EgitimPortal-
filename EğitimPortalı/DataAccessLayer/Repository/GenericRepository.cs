using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private Context _context;

		public GenericRepository(Context context)
		{
			_context = context;
		}

		public void AddAsync(T entity)
		{
			_context.Add(entity);
			_context.SaveChanges();

		}

		public void DeleteAsync(T entity)
		{
			_context.Remove(entity);
		}

		public IList<T> GetAllAsync()
		{
			return _context.Set<T>().ToList();
		}

		public T GetById(int id)
		{
			return _context.Set<T>().Find(id);
		}

		

		public void UpdateAsync(T entity)
		{
			_context.Update(entity);
			_context.SaveChanges();
		}
	}
}
