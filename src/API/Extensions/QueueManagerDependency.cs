using System;
using System.Reflection;
using API.BackgroundServices;
using MassTransit;

namespace API.Extensions
{
    public static class QueueManagerDependency
    {
        public static Task AddQueueManager(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                var entryAssembly = Assembly.GetEntryAssembly();
                x.AddConsumers(entryAssembly);

                x.UsingInMemory((context, config) =>
                {
                    config.ConfigureEndpoints(context);
                });
            });

            return Task.CompletedTask;
        }
    }
    public static class BackgroundServicesDependency
    {
        public static Task AddBackgroundServices(this IServiceCollection services)
        {
            services.AddHostedService<Worker>();

            return Task.CompletedTask;
        }
    }
}

