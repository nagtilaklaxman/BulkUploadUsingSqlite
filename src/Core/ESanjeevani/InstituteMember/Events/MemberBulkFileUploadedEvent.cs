using System;
namespace Core.ESanjeevani.InstituteMember.Events
{
    public class FileUploadedEvent
    {
        public string SessionId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
    }
    public class LogDBCreatedEvent
    {
        public string SessionId { get; set; }
        public string DbName { get; set; }
        public string Path { get; set; }
    }
    public class DataAddedInLocalDBEvent
    {
        public string SessionId { get; set; }
    }
    public class ValidatedEvent
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
    public class DataModifiedInLocalDBEvent
    {
        public string SessionId { get; set; }
        public IList<string> RecordId { get; set; }
    }
    public class DataDeletedInLocalDBEvent
    {
        public string SessionId { get; set; }
        public IList<string> RecordId { get; set; }
    }
    public class InstituteCreatedInPrimaryDBEvent
    {
        public string SessionId { get; set; }
        public int LocalRecordId { get; set; }
        public string PrimaryDbRecordId { get; set; }
    }
    public class PrimaryMemberCreatedInPrimaryDBEvent
    {
        public string SessionId { get; set; }
        public int LocalRecordId { get; set; }
        public string PrimaryDbRecordId { get; set; }
    }
    public class SecondaryMemberCreatedInPrimaryDBEvent
    {
        public string SessionId { get; set; }
        public int LocalRecordId { get; set; }
        public string PrimaryDbRecordId { get; set; }
    }

}

