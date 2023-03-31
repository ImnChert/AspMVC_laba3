using BLL.Mappings;
using BLL.Services.Data;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class ServiceProviderExtensions
    {
        public static void AddBLLServices(this IServiceCollection services)
        {
            services.AddDAL();

            services.AddAutoMapper(typeof(UserProfile), typeof(ForumProfile), typeof(ForumMessageProfile));

            services.AddScoped<UserDataService>();
            services.AddScoped<ForumDataService>();
            services.AddScoped<ForumMessageDataServcie>();
        }
    }
}
