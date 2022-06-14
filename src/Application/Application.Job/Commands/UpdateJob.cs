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
    private readonly INotificationService<JobRecord> _notificationService;
    private readonly ILogger<CreateJob> _logger;

    public UpdateJobHandler(IRepository<JobRecord> repository,INotificationService<JobRecord> notificationService, ILogger<CreateJob> logger)
    {
        _repository = repository;
        _notificationService = notificationService;
        _logger = logger;
    }

    public async Task<bool> Handle(UpdateJob request, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(request.JobRecord);
        _logger.LogInformation($" Update job SessionId: {request.JobRecord.SessionId} ModuleName : {request.JobRecord.ModuleName}");
        await _notificationService.Notify(request.JobRecord);
        return true;
    }
}