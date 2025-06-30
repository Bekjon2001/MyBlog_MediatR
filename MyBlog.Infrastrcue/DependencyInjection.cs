using MayBlog.Application.Abstrakctions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyBlog.Infrastrcue.Persistence;

namespace MyBlog.Infrastrcue
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastrcue(
            this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<IApplictionDbContext, ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            });

            return services;
        }

    }
}
