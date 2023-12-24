using Microsoft.Extensions.DependencyInjection;
using ProjectCar.Services.Interface;
using ProjectCar.Services.Service;

namespace ProjectCar.Services.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITimetableService, TimetableService>();
        }
    }
}