using Business.Services;
using Business.Services.Contracts;
using DAL.Repository.Contract;
using DAL.Repository;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utility;

namespace IOC
{
    public static class Dependencies
    {
        public static void InyectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Actividad1dbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
            });

            //Inyección de dependencias
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductCommentService, ProductCommentService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStoreCommentService, StoreCommentService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}