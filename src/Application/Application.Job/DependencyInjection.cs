using Application.Job.Commands;
using Domain.Common.interfaces;
using MediatR;
using MediatR.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Job;

public static class DependencyInjection
{
    public static IServiceCollection AddJobApplication(this IServiceCollection services)
    {
        //Add mediator assemblies here
        services.AddMediatR(typeof(CheckPendingJob).Assembly);

        services.AddScoped<ModuleJobHandlerResolver>(serviceProvider => moduleName =>
        {
            IJobRecordCommand command = null;
            switch (moduleName)
            {
                /*case ModuleNames.Esanjeevani.InstituteMember:
                    command = serviceProvider.GetRequiredService<RunJobForInstituteMember>();
                    break;*/
                default:
                    command = serviceProvider.GetRequiredService<NoJobModuleRegistered>();
                    break;
            }

            return command;

        });

        services.AddSingleton<Publisher>();
        return services;
    }
}