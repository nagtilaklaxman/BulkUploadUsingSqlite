using Domain.Common.Entities;
using Domain.Common.interfaces.Repository;
using Domain.ESanjeevani.InstituteMember.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.ESanjeevani.InstituteMember.Commands;

public class CreateJob :IRequest<JobRecord>
{
    public string SessionId { get; set; }
    public string FileName { get; set; }
    public string Path { get; set; }
}

public class CreateJobHandler : IRequestHandler<CreateJob, JobRecord>
{
    private readonly IRepository<JobRecord> _repository;
    private readonly ILogger<CreateJob> _logger;

    public CreateJobHandler(IRepository<JobRecord> repository, ILogger<CreateJob> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<JobRecord> Handle(CreateJob request, CancellationToken cancellationToken)
    {
        var jobData = new InstituteMemberJobData()
        {
            FilePath = request.Path,
            Status = InstituteMemberTaskStatus.FileReceived,
            Message = "File Received for Processing",
            SessionId = request.SessionId
        };
        var record = new JobRecord()
        {
            ModuleName = "module.esanjeevani.institutemember",
            SessionId = request.SessionId,
            JobData = JsonConvert.SerializeObject(jobData)
        };
        await _repository.AddAsync(record);
        _logger.LogInformation(" CreateJob : Received File : {Text} and  SessionId : {SessionId} ", request.FileName, request.SessionId);

        return record;
    }
}
