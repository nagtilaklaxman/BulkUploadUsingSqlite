using Domain.Common.Entities;
using Domain.Common.interfaces;
using Domain.Common.interfaces.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Job.Commands;

public class NotifyClient : IRequest<JobRecord>
{
    public string SessionId { get; set; }
}

public class NotifyClientHandler : IRequestHandler<NotifyClient, JobRecord>
{
    private readonly IJobRepository _jobRepository;
    private readonly INotificationService<JobRecord> _notificationService;
    private readonly ILogger<NotifyClientHandler> _logger;

    public NotifyClientHandler(IJobRepository jobRepository, INotificationService<JobRecord> notificationService, ILogger<NotifyClientHandler> logger)
    {
        _jobRepository = jobRepository;
        _notificationService = notificationService;
        _logger = logger;
    }
    public async Task<JobRecord> Handle(NotifyClient request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.SessionId))
        {
            throw new ArgumentNullException(nameof(request.SessionId));
        }

        var jobRecord = await _jobRepository.GetJobBySessionId(request.SessionId);
        await _notificationService.Notify(jobRecord);
        return jobRecord;
    }
}