using System;
using Core.ESanjeevani.InstituteMember.Events;
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
                try
                {
                    //await _bus.Publish(new FileUploadedEvent { FileName = "test.xlsx", Path = $"{sessionId}/test.xlsx", SessionId = sessionId.ToString() }, stoppingToken);

                    await Task.Delay(30000, stoppingToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}

