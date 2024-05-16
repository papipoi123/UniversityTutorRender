using Applications;
using Applications.Interfaces;
using Applications.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<ICurrentTimeService, CurrentTimeService>();

            //
            //services.AddScoped<ICertificationService, CertificationService>();
            //services.AddScoped<ICourseMajorService, CourseMajorService>();
            //services.AddScoped<IMailService, MailService>();
            //services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IReportService, ReportService>();
            //services.AddScoped<IStudentService, StudentService>();
            //services.AddScoped<ITeachingCourseService, TeachingCourseService>();
            //services.AddScoped<ITransactionService, TransactionService>();
            //services.AddScoped<ITutorFeedbackService, TutorFeedbackService>();
            //services.AddScoped<ITutorService, TutorService>();
            //services.AddScoped<IUniversityService, UniversityService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IWeeklyTimeService, WeeklyTimeService>();
            //services.AddScoped<IDashboardService, DashboardService>();


            return services;
        }
    }
}
