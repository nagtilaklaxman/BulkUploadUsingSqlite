using Core.ESanjeevani.InstituteMember.Repository;
using Infrastructure.ESanjeevani.InstituteMember.Migrations;
using Infrastructure.ESanjeevani.InstituteMember.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ESanjeevani.InstituteMember.Jobs;

public static class InstituteMemberExtensions
{
    public static IServiceCollection AddInstituteMember(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        services.AddScoped<IInstituteMemberSession, InstituteMemberSession>();
        services.AddScoped<IInstituteMemberConnectionFactory, InstituteMemberConnectionFactory>();
        services.AddScoped<IInstituteMemberMigrator, InstituteMemberMigrator>();
        services.AddScoped<IInstituteMemberBulkEntityRepository, InstituteMemberBulkEntityRepository>();
        return services;
    }
    public static IServiceCollection AddInstituteMember(this IServiceCollection services, Action<InstituteMemberOptions> setupAction)
    {
        if (setupAction == null)
        {
            throw new ArgumentNullException(nameof(setupAction));
        }
        services.AddInstituteMember();
        services.Configure(setupAction);
        return services;
    }
}