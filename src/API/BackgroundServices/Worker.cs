using System;
using Core.Events;
using MassTransit;

namespace API.BackgroundServices
{
    public class Worker : BackgroundService
    {
        readonly IBus _bus;

        public Worker(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var sessionId = Guid.NewGuid();
                await _bus.Publish(new MemberBulkFileUploadedEvent { FileName = "test.xlsx", Path = $"{sessionId}/test.xlsx", SessionId = sessionId.ToString() }, stoppingToken);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

