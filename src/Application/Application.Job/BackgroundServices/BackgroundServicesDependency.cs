using Microsoft.Extensions.DependencyInjection;

namespace Application.Job.BackgroundServices
{
    public static class BackgroundServicesDependency
    {
        public static IServiceCollection AddBackgroundService(this IServiceCollection services, Action<BackgroundServiceOptions> action)
        {
            services.AddHostedService<Worker>();
            services.Configure(action);
            return services;
        }
    }
}

