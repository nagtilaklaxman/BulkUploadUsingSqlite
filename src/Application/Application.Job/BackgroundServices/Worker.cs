using Application.Job.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Job.BackgroundServices
{
    public class Worker : BackgroundService
    {
        
        private readonly IServiceProvider _provider;
        private readonly IOptionsMonitor<BackgroundServiceOptions> _optionsMonitor;
        private readonly ILogger<Worker> _logger;


        public Worker(IServiceProvider provider, IOptionsMonitor<BackgroundServiceOptions> optionsMonitor, ILogger<Worker> logger)
        {
            _provider = provider;
            _optionsMonitor = optionsMonitor;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("worker service is running");
                    using (var scope = _provider.CreateScope())
                    {
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        await mediator.Send(new CheckPendingJob()
                        {
                           CurrentDate = DateTime.UtcNow
                        }, stoppingToken);
                        
                        await Task.Delay(_optionsMonitor.CurrentValue.Interval, stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}

