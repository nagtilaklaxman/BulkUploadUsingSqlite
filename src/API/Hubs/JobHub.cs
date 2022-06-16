using Application.Job.Commands;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.Hubs;

public class JobHub : Hub
{
    private readonly ILogger<JobHub> _logger;
    private readonly IMediator _mediator;

    public JobHub(ILogger<JobHub> logger,IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"connected to job hub connectionId :{Context.ConnectionId}");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation($"connectionId :{Context.ConnectionId} got disconnected. Is aborted : {Context.ConnectionAborted} with error : {exception?.Message}");
        //on disconnection signalr removes connection from group so dont need to remove manually.
        return base.OnDisconnectedAsync(exception);
    }

    public async Task Subscribe(string sessionId)
    {
        if (string.IsNullOrWhiteSpace(sessionId)) throw new ArgumentNullException(nameof(sessionId));
        await Groups.AddToGroupAsync(Context.ConnectionId, sessionId);
        var cancellationToken = CancellationToken.None;
        await _mediator.Send(new NotifyClient() { SessionId = sessionId }, cancellationToken);
        _logger.LogInformation($"connectionId {Context.ConnectionId} added to group {sessionId}");
    }
}