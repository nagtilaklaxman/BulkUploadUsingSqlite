
using Infrastructure.ESanjeevani.InstituteMember.Jobs;
using Infrastructure.FileHelper;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.FileHelper;
using Infrastructure.Jobs;
using Infrastructure.ESanjeevani.InstituteMember.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.Scan(scan => scan
            // We start out with all types in the assembly of ITransientService
            .FromCallingAssembly()
            .AddClasses(classes => classes.AssignableTo(typeof(IFileHelper<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo<IInstituteMemberMigration>())
            .As<IInstituteMemberMigration>()
            .WithScopedLifetime()
            );

            services.AddBulkJob(options =>
            {
                options.UseSqlite("Data/BulkUploadRequestsDB.db");
                options.Interval = TimeSpan.FromMinutes(5);
            });
            services.AddInstituteMember(options =>
            {
                options.UseSqlite("logs", "uploadLog");
            });
            services.AddScoped(typeof(ICsvHelper<>), typeof(CsvHelper<>));
            services.AddScoped(typeof(IExcelHelper<>), typeof(ExcelHelper<>));
          

            return services;
        }
    }
}

