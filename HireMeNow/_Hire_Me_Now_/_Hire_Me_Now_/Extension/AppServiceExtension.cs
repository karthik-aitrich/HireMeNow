using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace _Hire_Me_Now_.Extension
{
    public static class AppServiceExtension
    {
        public static IServiceCollection AddAppService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DbHireMeNowWebApiContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
