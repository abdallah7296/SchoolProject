using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Services.Abstracts;
using SchoolProject.Services.Services;

namespace SchoolProject.Services
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }

    }
}
