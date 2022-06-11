using Infrastructure.ESanjeevani.InstituteMember.Commands;
using Infrastructure.ESanjeevani.InstituteMember.Jobs;
using MediatR;
using Microsoft.Extensions.Options;

namespace API.BackgroundServices
{
    public class Worker : BackgroundService
    {
       
        private readonly IOptionsMonitor<InstituteMemberOptions> _options;
        private readonly IServiceProvider _provider;


        public Worker(IOptionsMonitor<InstituteMemberOptions> options, IServiceProvider provider)
        {
            _options = options;
            _provider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
               
                try
                {
                    using (var scope = _provider.CreateScope())
                    {
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        var sessionId = Guid.NewGuid();
                      
                        _options.CurrentValue.SetSession(sessionId.ToString());
                        await mediator.Publish(new AddRecordsFromFile()
                        {
                            FilePath = $"logs/146c1991-83e1-4884-b139-4d7890c2d6d3/CH 19.xlsx",
                            SessionId = "146c1991-83e1-4884-b139-4d7890c2d6d3"
                        }, stoppingToken);
                        await Task.Delay(150000, stoppingToken);
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

