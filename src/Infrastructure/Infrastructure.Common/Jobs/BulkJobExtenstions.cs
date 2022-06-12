using Domain.Common.Entities;
using Domain.Common.interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.Jobs;

public static class BulkJobExtenstions
{
    public static IServiceCollection AddBulkJob(this IServiceCollection services, Action<JobOptions> setupAction)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (setupAction == null)
        {
            throw new ArgumentNullException(nameof(setupAction));
        }

        services.AddScoped<IRepository<JobRecord>, JobRepository>();
        services.Configure(setupAction);
        return services;
    }
}