namespace BlazorWebAssemblyClient.Models
{
    public class FileUploadRequest
    {
        public int RecordsToUpload { get; set; }
    }
    public class FileUploadResult
    {
        public bool Uploaded { get; set; }
        public string? FileName { get; set; }
        public string? StoredFileName { get; set; }
        public int ErrorCode { get; set; }
    }
}

