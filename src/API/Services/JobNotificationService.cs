using API.Hubs;
using Domain.Common.Entities;
using Domain.Common.interfaces;
using Domain.ESanjeevani.InstituteMember.Entities;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.Services;

public class JobNotificationService : INotificationService<JobRecord>
{
    private readonly IHubContext<JobHub> _hubContext;

    public JobNotificationService(IHubContext<JobHub> hubContext)
    {
        _hubContext = hubContext;
    }
    public async Task Notify(JobRecord data)
    {
        var jobData = data.GetJobData<InstituteMemberJobData>();
        var jobProgressModel = new JobProgressModel()
        {
            SessionId = data.SessionId,
            ModuleName = data.ModuleName,
            Status = Enum.GetName(jobData.Status),
            Message = jobData.Message
        };
        await _hubContext.Clients.Group(data.SessionId).SendAsync("ReceiveMessage", jobProgressModel);
    }
}
public class JobProgressModel
{
    public string SessionId { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
    public string ModuleName { get; set; }
}