using Application.ESanjeevani.InstituteMember.Behaviors;
using Application.ESanjeevani.InstituteMember.Commands;
using Application.Job;
using Application.Job.Commands;
using Domain.Common.interfaces;
using Domain.Common.interfaces.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ESanjeevani.InstituteMember;

public static class DependencyInjection
{
    public static IServiceCollection AddESanjeevaniInstituteMemberApplication(this IServiceCollection services)
    {
        services.AddJobApplication();
        services.AddMediatR(typeof(CheckPendingJob).Assembly,typeof(AddRecordsFromFile).Assembly);
        services.AddScoped<ModuleJobHandlerResolver>(serviceProvider => moduleName =>
        {
            IJobRecordCommand command = moduleName switch
            {
                ModuleNames.Esanjeevani.InstituteMember =>
                    serviceProvider.GetRequiredService<RunJobForInstituteMember>(),
                _ => serviceProvider.GetRequiredService<NoJobModuleRegistered>()
            };
            return command;
        });
        services.AddScoped<RunJobForInstituteMember>();
        services.AddScoped<NoJobModuleRegistered>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(NotificationBehavior<,>));
        return services;
    }
}