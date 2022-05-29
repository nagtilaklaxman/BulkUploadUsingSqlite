using System;
namespace API.Models
{
    public class FileUploadResult
    {
        public bool Uploaded { get; set; }
        public string? FileName { get; set; }
        public string? StoredFileName { get; set; }
        public string SessionId { get; set; }
        public int ErrorCode { get; set; }
    }
}

