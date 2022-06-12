using Domain.ESanjeevani.InstituteMember.Migrations;
using Infrastructure.ESanjeevani.InstituteMember.Jobs;
using Infrastructure.ESanjeevani.InstituteMember.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ESanjeevani.InstituteMember;

public static class DependencyInjection
{
    public static IServiceCollection AddESanjeevaniInstituteMemberInfrastructure(this IServiceCollection services)
    {
        services.Scan(scan => scan
            // We start out with all types in the assembly of ITransientService
            .FromCallingAssembly()
            .AddClasses(classes => classes.AssignableTo(typeof(IInstituteMemberMigration)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        
        services.AddInstituteMember(options =>
        {
            options.UseSqlite("logs", "uploadLog.db");
        });
        return services;
    }
}