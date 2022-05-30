using System.Net;
using API.Controllers;
using API.Models;
using Core.Entities;
using Infrastructure.ESanjeevani.InstituteMember.FileHelper;
using Infrastructure.Interfaces.FileHelper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

public class FilesaveController : ApplicationController
{
    private readonly IWebHostEnvironment env;
    private readonly ILogger<FilesaveController> logger;
    private readonly IFileHelper<InstituteMemberExcelEntity> _fileHelper;

    public FilesaveController(IWebHostEnvironment env,
        ILogger<FilesaveController> logger, IFileHelper<InstituteMemberExcelEntity> fileHelper)
    {
        this.env = env;
        this.logger = logger;
        _fileHelper = fileHelper;
    }

    [HttpPost]
    public async Task<IActionResult> PostFile(
        [FromForm] IFormFile file)
    {

        var sessionId = Guid.NewGuid().ToString();

        var uploadResult = new FileUploadResult();
        var untrustedFileName = file.FileName;
        uploadResult.FileName = untrustedFileName;
        uploadResult.SessionId = sessionId;
        var trustedFileNameForDisplay =
            WebUtility.HtmlEncode(untrustedFileName);
        try
        {
            var path = Path.Combine(env.ContentRootPath,
                "logs", sessionId,
                untrustedFileName);

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var result = await _fileHelper.SaveAsync(stream, path);
                if (result.IsFailure)
                {
                    return Error(result.Error);
                }
                logger.LogInformation("{FileName} saved at {Path}",
                      trustedFileNameForDisplay, path);

                uploadResult.Uploaded = true;
                return Ok(uploadResult);
            };

        }
        catch (IOException ex)
        {
            logger.LogError("{FileName} error on upload (Err: 3): {Message}",
                trustedFileNameForDisplay, ex.Message);
            return Error(Errors.General.InternalServerError(ex.Message));
        }

    }
}

