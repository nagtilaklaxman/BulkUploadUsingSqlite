
using Domain.Common.interfaces;
using Domain.Common.interfaces.FileHelper;
using Domain.Common.interfaces.Repository;
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
           
            services.AddBulkJob(options =>
            {
                options.UseSqlite("Data/BulkUploadRequestsDB.db");
                options.Interval = TimeSpan.FromMinutes(5);
            });
            services.AddScoped(typeof(ICsvHelper<>), typeof(CsvHelper<>));
            services.AddScoped(typeof(IExcelHelper<>), typeof(ExcelHelper<>));
            services.AddScoped<IJobRepository, JobRepository>();
            return services;
        }
    }
}

