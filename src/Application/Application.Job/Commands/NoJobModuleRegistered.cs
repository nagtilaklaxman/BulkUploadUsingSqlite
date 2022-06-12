using Domain.Common.Entities;
using Domain.Common.interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Job.Commands;

public class NoJobModuleRegistered : IRequest<JobRecord>, IJobRecordCommand
{
    public string ModuleName { get; set; }
    public JobRecord JobRecord { get; set; }
}

public class NoModuleRegisteredHandler : IRequestHandler<NoJobModuleRegistered,JobRecord>
{
    private readonly ILogger<NoModuleRegisteredHandler> _logger;

    public NoModuleRegisteredHandler(ILogger<NoModuleRegisteredHandler> logger)
    {
        _logger = logger;
    }
    public async Task<JobRecord> Handle(NoJobModuleRegistered request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Job Module not registered for {request.ModuleName} and job id {request.JobRecord.Id}");
        return request.JobRecord;
    }
}