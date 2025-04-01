using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entity;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository(configuration);
            services.AddServices(configuration);
            
        }

        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PRN222ProjectTeamContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IContact, ContactService>();
            services.AddScoped<ICourse, CourseService>();
            services.AddScoped<IEnrollment, EnrollmentService>();
            services.AddScoped<INewsEvent, NewsEventService>();
            services.AddScoped<IProject, ProjectService>();
            services.AddScoped<IResource, ResourceService>();
            services.AddScoped<IUser, UserService>();
            services.AddScoped<IVnPay, VnPayService>();
            
        }
    }
}
