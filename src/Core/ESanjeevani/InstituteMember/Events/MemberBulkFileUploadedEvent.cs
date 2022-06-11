using System;
namespace Core.ESanjeevani.InstituteMember.Events
{
    public class FileUploadedEvent
    {
        public string SessionId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
    }
    public class AddDataFromFileCommand 
    {
        public string SessionId { get; set; }
        public string FilePath { get; set; }
    }

    public class ValidateDataCommand
    {
        public string SessionId { get; set; }
    }
    
    public class DataAddedEvent
    {
        public string SessionId { get; set; }
    }
    public class RecordValidatedEvent
    {
        public string SessionId { get; set; }
        public int RecordId { get; set; }
        public IList<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();
    }
    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
    public class DataModifiedEvent
    {
        public string SessionId { get; set; }
        public IReadOnlyList<int> RecordIds { get; set; }
    }
    public class DataDeletedEvent
    {
        public string SessionId { get; set; }
        public IReadOnlyList<int> RecordIds { get; set; }
    }
    public class InstituteCreatedEvent
    {
        public string SessionId { get; set; }
        public int LocalRecordId { get; set; }
        public string PrimaryDbRecordId { get; set; }
    }
    public class PrimaryMemberCreatedEvent
    {
        public string SessionId { get; set; }
        public int LocalRecordId { get; set; }
        public string PrimaryDbRecordId { get; set; }
    }
    public class SecondaryMemberCreatedEvent
    {
        public string SessionId { get; set; }
        public int LocalRecordId { get; set; }
        public string PrimaryDbRecordId { get; set; }
    }
}

