using System;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Infrastructure.contexts;
using Infrastructure.FileHelper;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.FileHelper;
using Infrastructure.Interfaces.Migrations;
using Infrastructure.Migrations.Scripts.ESanjeevani.InstituteMember;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(ICsvHelper<>), typeof(CsvHelper<>));
            services.AddScoped(typeof(IExcelHelper<>), typeof(ExcelHelper<>));

            services.AddScoped<IUploaderLogDBConnectionStringModifier, UploaderLogDBConnectionStringReader>();
            services.AddScoped<IConnectionStringReader, UploaderLogDBConnectionStringReader>();

            services.AddScoped<IInstituteMemberMigration, AddAuditTrailTable>();
            services.AddScoped<IInstituteMemberMigration, AddBulkEntityValidationTable>();
            services.AddScoped<IInstituteMemberMigration, AddInstituteMemberBulkEntityTable>();
            services.AddScoped<IInstituteMemberMigration, AddInstituteTable>();
            services.AddScoped<IInstituteMemberMigration, AddInstitutionMemberTable>();
            services.AddScoped<IInstituteMemberMigration, AddLoginTable>();
            services.AddScoped<IInstituteMemberMigration, AddMemberMenuTable>();
            services.AddScoped<IInstituteMemberMigration, AddMemberSlotTable>();
            services.AddScoped<IInstituteMemberMigration, AddMemberTable>();

            services.AddScoped<IUploaderLogDBContext, UploaderLogDBContext>();

            /*services.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddSQLite()
                // Set the connection string
                //.WithGlobalConnectionString("Data Source=logs/test.db")
                // Define the assembly containing the migrations
                .ScanIn(typeof(AddInstituteTable).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole());*/


            return services;
        }
    }
}

