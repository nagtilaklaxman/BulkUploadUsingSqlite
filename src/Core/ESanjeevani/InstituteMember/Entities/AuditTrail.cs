namespace Core.ESanjeevani.InstituteMember.Entities
{
    /// <summary>
    /// Log table of data manipulation
    /// </summary>
    public class AuditTrail
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string IconPath { get; set; }
        public int MemberId { get; set; }
        public string ModuleId { get; set; }
        public string EventId { get; set; }
        public string AccessType { get; set; }
        public string LocationIPAddress { get; set; }
        public string SourceId { get; set; }
        public string UserTypeId { get; set; }
    }
}

