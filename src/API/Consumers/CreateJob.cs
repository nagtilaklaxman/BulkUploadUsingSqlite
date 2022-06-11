using Core.ESanjeevani.InstituteMember.Events;
using Core.ESanjeevani.InstituteMember.Repository;
using Core.interfaces.Repository;
using Infrastructure.ESanjeevani.InstituteMember.Jobs;
using Infrastructure.Jobs;
using MassTransit;
using Newtonsoft.Json;

namespace API.Consumers;

public class CreateJob : IConsumer<FileUploadedEvent>
{
    private readonly IRepository<JobRecord> _repository;
    private readonly ILogger<CreateJob> _logger;

    public CreateJob(IRepository<JobRecord> repository, ILogger<CreateJob> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task Consume(ConsumeContext<FileUploadedEvent> context)
    {
        var jobData = new InstituteMemberJobData()
        {
            FilePath = context.Message.Path,
            Status = InstituteMemberTaskStatus.FileReceived,
            Message = "File Received for Processing",
            SessionId = context.Message.SessionId
        };
        var record = new JobRecord()
        {
            ModuleName = "module.esanjeevani.institutemember",
            SessionId = context.Message.SessionId,
            JobData = JsonConvert.SerializeObject(jobData)
        };
        await _repository.AddAsync(record);
        _logger.LogInformation(" CreateJob : Received File : {Text} and  SessionId : {SessionId} ", context.Message.FileName, context.Message.SessionId);
    }
    public class AddDataFromFileHandler: IConsumer<AddDataFromFileCommand>
    {
        private readonly ILogger<AddDataFromFileHandler> _logger;
        private readonly IServiceProvider _provider;

        public AddDataFromFileHandler(ILogger<AddDataFromFileHandler> logger, IServiceProvider provider )
        {
            _logger = logger;
            _provider = provider;
        }
        public async Task Consume(ConsumeContext<AddDataFromFileCommand> context)
        {
            using (var scope = _provider.CreateScope())
            {
                var unitofWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
               await unitofWork.SetSession(context.Message.SessionId);
                _logger.LogInformation($"AddDataFromFileCommand received repository {unitofWork.BulkEntities.Connectionstring} ", context.Message);
                await Task.Delay(5000);
                _logger.LogInformation($"After delay Value of repository : {unitofWork.BulkEntities.Connectionstring}");
            }
        }
    }
}