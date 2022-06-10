using System;
using Core.ESanjeevani.InstituteMember.Events;
using Infrastructure.ESanjeevani.InstituteMember.Jobs;
using MassTransit;
using Microsoft.Extensions.Options;

namespace API.BackgroundServices
{
    public class Worker : BackgroundService
    {
        readonly IBus _bus;
        private readonly IServiceProvider _serviceProvider;


        public Worker(IBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
               
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var sessionId = Guid.NewGuid();
                        var options = scope.ServiceProvider.GetRequiredService<IOptionsMonitor<InstituteMemberOptions>>();
                        options.CurrentValue.SetSession(sessionId.ToString());
                        
                        var sendEndpoint = await _bus.GetPublishSendEndpoint<AddDataFromFileCommand>();
                        
                        await sendEndpoint.Send<AddDataFromFileCommand>(
                            new ()
                            {
                                FilePath = $"{sessionId}/test.xlsx",
                                SessionId = sessionId.ToString()
                            }, stoppingToken);
                    }

                    await Task.Delay(3000, stoppingToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}

