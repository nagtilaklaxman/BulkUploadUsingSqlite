using System;
using System.Reflection;
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
}

