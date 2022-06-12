using Domain.Common.Entities;
using Domain.Common.interfaces;
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
        /*await _unitOfWork.SetSession(request.JobRecord.SessionId);
        var bulkEntities = await _unitOfWork.BulkEntities.GetAllAsync();
        foreach (var entity in bulkEntities)
        {
            
        }*/
        _logger.LogInformation("job request received in instituteMember");
        return request.JobRecord;
    }
}