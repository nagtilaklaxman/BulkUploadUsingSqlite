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
        private readonly IInstituteMemberBulkEntityRepository _repository;

        public AddDataFromFileHandler(ILogger<AddDataFromFileHandler> logger ,IInstituteMemberBulkEntityRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public async Task Consume(ConsumeContext<AddDataFromFileCommand> context)
        {
           _logger.LogInformation($"AddDataFromFileCommand received repository {_repository.Connectionstring} ", context.Message);
           await Task.Delay(5000);
           _logger.LogInformation($"After delay Value of repository : {_repository.Connectionstring}");
        }
    }
}