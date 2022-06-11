using Core.ESanjeevani.InstituteMember.Entities;
using Core.ESanjeevani.InstituteMember.Repository;
using Infrastructure.ESanjeevani.InstituteMember.FileHelper;
using Infrastructure.ESanjeevani.InstituteMember.Jobs;
using Infrastructure.Interfaces;
using Infrastructure.Interfaces.FileHelper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.ESanjeevani.InstituteMember.Commands;

public class AddRecordsFromFile : INotification
{
    public string SessionId { get; set; }
    public string FilePath { get; set; }
}

public class AddRecordsFromFileHandler : INotificationHandler<AddRecordsFromFile>
{
    private readonly ILogger<AddRecordsFromFileHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExcelHelper<InstituteMemberExcelEntity> _excelHelper;
    private readonly IMapper<InstituteMemberExcelEntity, InstituteMemberBulkEntity> _mapper;

    public AddRecordsFromFileHandler(ILogger<AddRecordsFromFileHandler> logger ,IUnitOfWork unitOfWork, IExcelHelper<InstituteMemberExcelEntity> excelHelper
     , IMapper<InstituteMemberExcelEntity, InstituteMemberBulkEntity> mapper
    )
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _excelHelper = excelHelper;
        _mapper = mapper;
    }
    public async Task Handle(AddRecordsFromFile notification, CancellationToken cancellationToken)
    {
        var records = _excelHelper.Read(notification.FilePath);
        var bulkentities = await _mapper.Map(records);
        await _unitOfWork.SetSession(notification.SessionId);
        _logger.LogInformation($"Add records before  add : {_unitOfWork.BulkEntities.Connectionstring}");
        await _unitOfWork.BulkEntities.AddRangeAsync(bulkentities.ToList());
        _logger.LogInformation($"Add records after add : {_unitOfWork.BulkEntities.Connectionstring}");
    }
}