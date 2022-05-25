namespace Core.ESanjeevani.InstituteMember.Entities
{
    /// <summary>
    /// Many to Many mapping table
    /// Table : 
    /// </summary>
    public class InstitutionMember
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int InstitutionId { get; set; }
        public bool IsActive { get; set; }
        public string SourceId { get; set; }
    }
}

