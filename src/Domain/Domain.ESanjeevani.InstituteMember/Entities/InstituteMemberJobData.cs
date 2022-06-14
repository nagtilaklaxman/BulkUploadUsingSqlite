
namespace Domain.ESanjeevani.InstituteMember.Entities
{
    public class InstituteMemberJobData
    {
        public string SessionId { get; set; }
        public string FilePath { get; set; }
        public int RecordsReceived { get; set; }
        public int RecordsValid { get; set; }
        public int RecordsInvalid { get; set; }
        public int RecordsDeleted { get; set; }
        public InstituteMemberTaskStatus  Status { get; set; }
        public string Message { get; set; }
    }

    public enum InstituteMemberTaskStatus
    {
        FileReceived,
        DataReceived,
        DataValidated,
        ApprovedToImport,
        Completed
    }
}

