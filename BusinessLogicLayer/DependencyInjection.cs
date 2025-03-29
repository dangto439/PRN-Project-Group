using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServices(configuration);
            services.AddRepository();
        }

        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IClass, ClassService>();
            services.AddScoped<IContact, ContactService>();
            services.AddScoped<ICourse, CourseService>();
            services.AddScoped<IEnrollment, EnrollmentService>();
            services.AddScoped<INewsEvent, NewsEventService>();
            services.AddScoped<IProject, ProjectService>();
            services.AddScoped<IResource, ResourceService>();
            services.AddScoped<IUser, UserService>();
        }
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
