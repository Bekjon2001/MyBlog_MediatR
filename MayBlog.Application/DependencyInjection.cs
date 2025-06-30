using System.Reflection;
using MayBlog.Application.Behaviors;
using MediatR;

namespace MayBlog.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>)); 
            return services;
        }
    }
}
