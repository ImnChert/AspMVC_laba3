using DAL.Data.Repositories;
using DAL.Data;
using DAL.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class ServiceProviderExtensions
    {
        public static void AddDAL(this IServiceCollection services)
        {
            services.AddScoped<ApplicationContext>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IForumRepository, ForumRepository>();
            services.AddScoped<IForumMessageReposiotry, ForumMessageRepository>();
        }
    }
}

