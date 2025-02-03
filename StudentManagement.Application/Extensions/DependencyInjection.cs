using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Application.Services.Interfaces;
using StudentManagement.Application.Services;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Persistance.Repositories;

namespace StudentManagement.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            //builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentServices, StudentServices>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();
            services.AddScoped<IFamilyServices, FamilyServices>();
            services.AddScoped<IMasterRepository, MasterRepository>();
            services.AddScoped<IMastersServices, MastersServices>();
            return services;
        }
    }
}
