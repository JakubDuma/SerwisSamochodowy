using Microsoft.Extensions.DependencyInjection;
using ProjectCar.Data.Interface;
using ProjectCar.Data.Repository;

namespace ProjectCar.Data.RepositoryRegistration
{
    public static class RepositoryRegistration
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IPartRepository, PartRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITimetableRepository, TimetableRepository>();
        }
    }
}