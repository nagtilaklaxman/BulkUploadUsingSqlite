using Domain.Common.Entities;
using Domain.Common.interfaces.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Job.Commands;

public class CreateJob :IRequest<bool>
{
    public JobRecord JobRecord { get; set; }
}

public class CreateJobHandler : IRequestHandler<CreateJob, bool>
{
    private readonly IRepository<JobRecord> _repository;
    private readonly ILogger<CreateJob> _logger;

    public CreateJobHandler(IRepository<JobRecord> repository, ILogger<CreateJob> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<bool> Handle(CreateJob request, CancellationToken cancellationToken)
    {
        /*var jobData = new InstituteMemberJobData()
        {
            FilePath = request.Path,
            Status = InstituteMemberTaskStatus.FileReceived,
            Message = "File Received for Processing",
            SessionId = request.SessionId
        };*/
       /* var record = new JobRecord()
        {
            ModuleName = ModuleNames.Esanjeevani.InstituteMember,
            SessionId = request.SessionId,
            JobData = JsonConvert.SerializeObject(jobData)
        };*/
        await _repository.AddAsync(request.JobRecord);
        _logger.LogInformation(" CreateJob : moduleName : {Text} and  SessionId : {SessionId} ", request.JobRecord.ModuleName, request.JobRecord.SessionId);

        return true;
    }
}
