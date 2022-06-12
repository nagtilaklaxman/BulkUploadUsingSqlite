
using Domain.Common.interfaces.FileHelper;
using Infrastructure.Common.FileHelper;
using Infrastructure.Common.Interfaces;
using Infrastructure.Common.Jobs;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCommonInfrastructure(this IServiceCollection services)
        {
            services.Scan(scan => scan
            // We start out with all types in the assembly of ITransientService
            .FromCallingAssembly()
            .AddClasses(classes => classes.AssignableTo(typeof(IFileHelper<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IMapper<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            );
            services.AddBulkJob(options =>
            {
                options.UseSqlite("Data/BulkUploadRequestsDB.db");
                options.Interval = TimeSpan.FromMinutes(5);
            });
            services.AddScoped(typeof(ICsvHelper<>), typeof(CsvHelper<>));
            services.AddScoped(typeof(IExcelHelper<>), typeof(ExcelHelper<>));
            return services;
        }
    }
}

