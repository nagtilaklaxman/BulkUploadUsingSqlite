using Domain.Common.interfaces.Repository;
using MediatR;

namespace Application.Job.Commands;

public class CheckPendingJob : IRequest<bool>
{
    public DateTime CurrentDate { get; set; } = DateTime.UtcNow;
}

public class CheckPendingJobHandler : IRequestHandler<CheckPendingJob, bool>
{
    private readonly ModuleJobHandlerResolver _jobHandlerResolver;
    private readonly IJobRepository _jobRepository;
    private readonly IMediator _mediator;

    public CheckPendingJobHandler(ModuleJobHandlerResolver jobHandlerResolver ,IJobRepository jobRepository, IMediator mediator)
    {
        _jobHandlerResolver = jobHandlerResolver;
        _jobRepository = jobRepository;
        _mediator = mediator;
    }
    public async Task<bool> Handle(CheckPendingJob request, CancellationToken cancellationToken)
    {
        var pendingJobs = await _jobRepository.GetPendingJobs(10);
        foreach (var job in pendingJobs)
        {
            var command = _jobHandlerResolver(job.ModuleName);
            if (command is not  null)
            {
                command.ModuleName = job.ModuleName;
                command.JobRecord = job;
                await _mediator.Send(command);
            }
        }
        return true;
    }
}