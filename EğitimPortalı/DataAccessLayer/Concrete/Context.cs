using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=LAPTOP-M81HR9O7;Database=EgitimPortal;MultipleActiveResultSets=True;TrustServerCertificate=True;Trusted_Connection=True;");
		}
         public DbSet<Training> Training { get; set; }
		public DbSet<Content> Content { get; set; }
		public DbSet<User> User { get; set; }

		public DbSet<Category> Category { get; set; }
		public DbSet<UserTraining> UserTraining { get; set; }

		
	}
}
