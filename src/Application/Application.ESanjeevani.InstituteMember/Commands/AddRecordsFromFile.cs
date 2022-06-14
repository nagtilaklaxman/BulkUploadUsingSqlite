using Application.Job.Commands;
using Domain.Common.Entities;
using Domain.ESanjeevani.InstituteMember;
using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.ESanjeevani.InstituteMember.Commands;

public class AddRecordsFromFile : IRequest<InstituteMemberCommandResponse>
{
    public AddRecordsFromFile(JobRecord jobRecord)
    {
        JobRecord = jobRecord;
    }
    public JobRecord JobRecord { get; }
}

public class AddRecordsFromFileHandler : IRequestHandler<AddRecordsFromFile,InstituteMemberCommandResponse>
{
    private readonly ILogger<AddRecordsFromFileHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstituteMemberExcelHelper _excelHelper;
    private readonly IMediator _mediator;


    public AddRecordsFromFileHandler(ILogger<AddRecordsFromFileHandler> logger ,IUnitOfWork unitOfWork
        ,IInstituteMemberExcelHelper excelHelper
        ,IMediator mediator
    )
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _excelHelper = excelHelper;
        _mediator = mediator;
    }
    public async Task<InstituteMemberCommandResponse> Handle(AddRecordsFromFile notification, CancellationToken cancellationToken)
    {
        var job = notification.JobRecord;
        var jobData = job.GetJobData<InstituteMemberJobData>();
        var records = await _excelHelper.Read(jobData.FilePath);
        await _unitOfWork.SetSession(jobData.SessionId);
        _logger.LogInformation($"Add records before  add : {_unitOfWork.BulkEntities.Connectionstring}");
        await _unitOfWork.BulkEntities.AddRangeAsync(records.ToList());
        _logger.LogInformation($"Add records after add : {_unitOfWork.BulkEntities.Connectionstring}");
        
        jobData.Status = InstituteMemberTaskStatus.DataReceived;
        jobData.RecordsReceived = records.Count;
        jobData.Message = $"Received {records.Count} records";
        
        job.SetJobData(jobData);
        
        var updateJobData = new UpdateJob()
        {
            JobRecord = job
        };
        await _mediator.Send(updateJobData, cancellationToken);
        
        return new InstituteMemberCommandResponse()
        {
            Status = "Pending for Validation", SessionId = jobData.SessionId,
            Message = $"Received {records.Count} records"
        };
    }
}