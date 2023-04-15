using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPOS.Persistance.Context;
namespace SPOS.Persistance
{
    public static class Injector
    {
        public static void AddPostgresQl(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SPOSContext>(p => p.UseSqlite(config.GetConnectionString("static")));
        }
    }
}
