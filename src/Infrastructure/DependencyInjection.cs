using System;
using FluentMigrator.Runner;
using Infrastructure.FileHelper;
using Infrastructure.Interfaces.FileHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(ICsvHelper<>), typeof(CsvHelper<>));
            services.AddScoped(typeof(IExcelHelper<>), typeof(ExcelHelper<>));


            services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddSQLite()
                    // Set the connection string
                    .WithGlobalConnectionString("Data Source=test.db"))
                // Define the assembly containing the migrations
                //.ScanIn(typeof(AddLogTable).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole());
            return services;
        }
    }
}

