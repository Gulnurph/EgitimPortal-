using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Extension
{
    public static class ServicesCollection
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services)
        {


          
            services.AddScoped<ITrainingDal, EfTrainingDal>();

            services.AddScoped<ITrainingServices, TrainingManager>();
            services.AddScoped<IContentDal, EfContentDal>();
            services.AddScoped<IContentServices, ContentManager>();
            services.AddScoped<ICategoryServices, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
