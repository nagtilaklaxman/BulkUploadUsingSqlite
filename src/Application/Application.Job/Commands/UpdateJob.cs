using Domain.Common.Entities;
using Domain.Common.interfaces;
using Domain.Common.interfaces.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Job.Commands;

public class UpdateJob :IRequest<bool>
{ 
    public JobRecord JobRecord { get; set; }
}

public class UpdateJobHandler : IRequestHandler<UpdateJob, bool>
{
    private readonly IRepository<JobRecord> _repository;
    private readonly ILogger<CreateJob> _logger;
    private readonly IMediator _mediator;

    public UpdateJobHandler(IRepository<JobRecord> repository, ILogger<CreateJob> logger,IMediator mediator)
    {
        _repository = repository;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<bool> Handle(UpdateJob request, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(request.JobRecord);
        _logger.LogInformation($" Update job SessionId: {request.JobRecord.SessionId} ModuleName : {request.JobRecord.ModuleName}");
        await _mediator.Send(new NotifyClient() { SessionId = request.JobRecord.SessionId },cancellationToken);
        return true;
    }
}