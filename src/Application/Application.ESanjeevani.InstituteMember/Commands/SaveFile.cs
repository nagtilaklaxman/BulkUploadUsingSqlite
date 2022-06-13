using System.Net;
using CSharpFunctionalExtensions;
using Domain.Common.Entities;
using Domain.ESanjeevani.InstituteMember;
using MediatR;

namespace Application.ESanjeevani.InstituteMember.Commands;

public class SaveFile : IRequest<Result<FileSaveResult,BulkError>>
{
    public Stream Stream { get; set; }
    public string FileName { get; set; }
}

public class FileSaveResult
{
    public bool IsUploaded { get; set; }
    public string? FileName { get; set; }
    public string? StoredFileName { get; set; }
    public string SessionId { get; set; }
}

public class SaveFileHandler : IRequestHandler<SaveFile, Result<FileSaveResult, BulkError>>
{
    private readonly IInstituteMemberExcelHelper _excelHelper;

    public SaveFileHandler(IInstituteMemberExcelHelper excelHelper)
    {
        _excelHelper = excelHelper;
    }
    public async Task<Result<FileSaveResult, BulkError>> Handle(SaveFile request, CancellationToken cancellationToken)
    {
        var sessionId = Guid.NewGuid().ToString();
        var trustedFileNameForDisplay =
            WebUtility.HtmlEncode(request.FileName);
        
        var path =  Path.Combine(
            "logs", sessionId,
            trustedFileNameForDisplay);
        
        var result = await _excelHelper.SaveAsync(request.Stream, path);
        
        if (!result.IsSuccess)
            return result.Error;

        // code to call CreateJob and CreateLogDatabase Event handlers
        
        var fileResult = new FileSaveResult()
        {
            FileName = request.FileName,
            IsUploaded = true,
            SessionId = sessionId,
            StoredFileName = trustedFileNameForDisplay
        };
        return fileResult;
    }
}