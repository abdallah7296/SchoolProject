using Microsoft.Extensions.DependencyInjection;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.infrastructure.infrastructure;
using SchoolProject.infrastructure.Repositories;

namespace SchoolProject.infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}
