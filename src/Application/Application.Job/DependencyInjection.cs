using Application.Job.BackgroundServices;
using MediatR.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Job;

public static class DependencyInjection
{
    public static IServiceCollection AddJobApplication(this IServiceCollection services)
    {
        //Add mediator assemblies here
        
        services.AddBackgroundService(options =>
        {
            options.Interval = TimeSpan.FromMinutes(1);
        });
        

        services.AddSingleton<Publisher>();

        return services;
    }
}