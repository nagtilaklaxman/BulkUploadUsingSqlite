namespace Core.Entities.ESanjeevani.InstituteMemberBulkModels
{
    public class MemberMenu
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string MemberId { get; set; }
        public string MenuMappingId { get; set; }
        public string IsActive { get; set; }
        public string InstitutionId { get; set; }
        public string SourceId { get; set; }
    }
}

