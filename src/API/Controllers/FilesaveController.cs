using System.Net;
using API.Models;
using Infrastructure.ESanjeevani.InstituteMember.FileHelper;
using Infrastructure.Interfaces.FileHelper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

[ApiController]
[Route("[controller]")]
public class FilesaveController : ControllerBase
{
    private readonly IWebHostEnvironment env;
    private readonly ILogger<FilesaveController> logger;
    private readonly IExcelHelper<InstituteMemberExcelEntity> _fileHelper;

    public FilesaveController(IWebHostEnvironment env,
        ILogger<FilesaveController> logger, IExcelHelper<InstituteMemberExcelEntity> fileHelper)
    {
        this.env = env;
        this.logger = logger;
        _fileHelper = fileHelper;
    }

    [HttpPost]
    public async Task<ActionResult<IList<FileUploadResult>>> PostFile(
        [FromForm] IEnumerable<IFormFile> files)
    {
        var maxAllowedFiles = 3;
        // long maxFileSize = 1024 * 1024 * 15;
        var filesProcessed = 0;
        var resourcePath = new Uri($"{Request.Scheme}://{Request.Host}/");
        List<FileUploadResult> uploadResults = new();
        var sessionId = Guid.NewGuid().ToString();
        foreach (var file in files)
        {
            var uploadResult = new FileUploadResult();
            // string trustedFileNameForFileStorage;
            var untrustedFileName = file.FileName;
            uploadResult.FileName = untrustedFileName;
            var trustedFileNameForDisplay =
                WebUtility.HtmlEncode(untrustedFileName);

            if (filesProcessed < maxAllowedFiles)
            {
                /*  if (file.Length == 0)
                {
                    logger.LogInformation("{FileName} length is 0 (Err: 1)",
                        trustedFileNameForDisplay);
                    uploadResult.ErrorCode = 1;
                }
                else if (file.Length > maxFileSize)
                {
                    logger.LogInformation("{FileName} of {Length} bytes is " +
                        "larger than the limit of {Limit} bytes (Err: 2)",
                        trustedFileNameForDisplay, file.Length, maxFileSize);
                    uploadResult.ErrorCode = 2;
                } */
                // else
                // {
                try
                {
                    //trustedFileNameForFileStorage = Path.GetRandomFileName();
                    var path = Path.Combine(env.ContentRootPath,
                        "logs", sessionId,
                        untrustedFileName);

                    // EnsureFolder(path);
                    // await using FileStream fs = new(path, FileMode.Create);
                    // await file.CopyToAsync(fs);
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        await _fileHelper.SaveAsync(stream, path);
                    };
                    logger.LogInformation("{FileName} saved at {Path}",
                        trustedFileNameForDisplay, path);
                    uploadResult.Uploaded = true;
                    uploadResult.StoredFileName = untrustedFileName;
                }
                catch (IOException ex)
                {
                    logger.LogError("{FileName} error on upload (Err: 3): {Message}",
                        trustedFileNameForDisplay, ex.Message);
                    uploadResult.ErrorCode = 3;
                }
                // }

                filesProcessed++;
            }
            else
            {
                logger.LogInformation("{FileName} not uploaded because the " +
                    "request exceeded the allowed {Count} of files (Err: 4)",
                    trustedFileNameForDisplay, maxAllowedFiles);
                uploadResult.ErrorCode = 4;
            }

            uploadResults.Add(uploadResult);
        }

        return new CreatedResult(resourcePath, uploadResults);
    }
    void EnsureFolder(string path)
    {
        string directoryName = Path.GetDirectoryName(path);
        // If path is a file name only, directory name will be an empty string
        if (directoryName.Length > 0)
        {
            // Create all directories on the path that don't already exist
            Directory.CreateDirectory(directoryName);
        }
    }
}

