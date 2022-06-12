using Domain.ESanjeevani.InstituteMember;
using Domain.ESanjeevani.InstituteMember.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.ESanjeevani.InstituteMember.Commands;

public class InstituteMemberCommandResponse
{
    public string SessionId { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
}
public class AddRecordsFromFile : IRequest<InstituteMemberCommandResponse>
{
    public string SessionId { get; set; }
    public string FilePath { get; set; }
}

public class AddRecordsFromFileHandler : IRequestHandler<AddRecordsFromFile,InstituteMemberCommandResponse>
{
    private readonly ILogger<AddRecordsFromFileHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstituteMemberExcelHelper _excelHelper;


    public AddRecordsFromFileHandler(ILogger<AddRecordsFromFileHandler> logger ,IUnitOfWork unitOfWork
        ,IInstituteMemberExcelHelper excelHelper
    )
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _excelHelper = excelHelper;
    }
    public async Task<InstituteMemberCommandResponse> Handle(AddRecordsFromFile notification, CancellationToken cancellationToken)
    {
        var records = await _excelHelper.GetAsync(notification.FilePath);
        await _unitOfWork.SetSession(notification.SessionId);
        _logger.LogInformation($"Add records before  add : {_unitOfWork.BulkEntities.Connectionstring}");
        await Task.Delay(5000);
        await _unitOfWork.BulkEntities.AddRangeAsync(records.ToList());
        _logger.LogInformation($"Add records after add : {_unitOfWork.BulkEntities.Connectionstring}");
        return new InstituteMemberCommandResponse()
        {
            Status = "Pending for Validation", SessionId = notification.SessionId,
            Message = $"Received {records.Count} records"
        };
    }
}