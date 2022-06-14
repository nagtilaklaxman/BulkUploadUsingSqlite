using Microsoft.AspNetCore.SignalR;

namespace API.Hubs;

public class JobHub : Hub
{
    private readonly ILogger<JobHub> _logger;

    public JobHub(ILogger<JobHub> logger)
    {
        _logger = logger;
    }

    public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"connected to job hub connectionId :{Context.ConnectionId}");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation($"connectionId :{Context.ConnectionId} got disconnected. Is aborted : {Context.ConnectionAborted} with error : {exception?.Message}");
        //on disconnection signalr remove from group so dont need to remove manually from group
        return base.OnDisconnectedAsync(exception);
    }

    public async Task Subscribe(string SessionId)
    {
        if (string.IsNullOrWhiteSpace(SessionId)) throw new ArgumentNullException(nameof(SessionId));
        await Groups.AddToGroupAsync(Context.ConnectionId, SessionId);
        _logger.LogInformation($"connectionId {Context.ConnectionId} added to group {SessionId}");
    }
}