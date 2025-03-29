using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            //services.AddScoped<IAuthenticationService, AuthenticationService>();
            //services.AddScoped<Authentication>();
            //services.AddScoped<ICourseService, CourseService>();
            //services.AddScoped<INotificationService, NotificationService>();
            //services.AddScoped<IChapterService, ChapterService>();
            //services.AddScoped<IEnrollmentService, EnrollmentService>();
            //services.AddScoped<ILessonService, LessonService>();
            //services.AddScoped<ILabService, LabService>();
            //services.AddScoped<IChapterProgressService, ChapterProgressSevice>();
            //services.AddScoped<ISubmissionService, SubmissionService>();
            //services.AddScoped<IPaymentService, PaymentService>();
            //services.AddScoped<IVnPayService, VnPayService>();
            //services.AddScoped<IDashboardService, DashboardService>();
            //services.AddScoped<FcmService>();

        }
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
