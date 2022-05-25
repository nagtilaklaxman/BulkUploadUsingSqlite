using API.BackgroundServices;

namespace API.Extensions
{
    public static class BackgroundServicesDependency
    {
        public static Task AddBackgroundServices(this IServiceCollection services)
        {
            services.AddHostedService<Worker>();

            return Task.CompletedTask;
        }
    }
}

