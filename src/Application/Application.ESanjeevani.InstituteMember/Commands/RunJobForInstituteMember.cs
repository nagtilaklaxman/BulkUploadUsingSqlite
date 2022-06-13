using Domain.Common.Entities;
using Domain.Common.interfaces;
using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.ESanjeevani.InstituteMember.Commands;

public class RunJobForInstituteMember : IRequest<JobRecord>, IJobRecordCommand
{
    public string ModuleName { get; set; }
    public JobRecord JobRecord { get; set; }
}

public class RunJobForInstituteMemberHandler : IRequestHandler<RunJobForInstituteMember, JobRecord>
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<RunJobForInstituteMemberHandler> _logger;

    public RunJobForInstituteMemberHandler(IMediator mediator, IUnitOfWork unitOfWork, ILogger<RunJobForInstituteMemberHandler> logger)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<JobRecord> Handle(RunJobForInstituteMember request, CancellationToken cancellationToken)
    {
        var jobData = request.JobRecord.GetJobData<InstituteMemberJobData>();

        IRequest<InstituteMemberCommandResponse> command;
        if (jobData != null)
        {
            command = jobData.Status switch
            {
                InstituteMemberTaskStatus.FileReceived => new AddRecordsFromFile(request.JobRecord),
                InstituteMemberTaskStatus.DataReceived => new ValidateData(request.JobRecord),
                InstituteMemberTaskStatus.ApprovedToImport => new AddRecordsFromFile(request.JobRecord)
            };
            if (command != null && _mediator != null)
            {
                await _mediator.Send(command);
            }
        }
        _logger.LogInformation("job request received in instituteMember");
        return request.JobRecord;
    }
}