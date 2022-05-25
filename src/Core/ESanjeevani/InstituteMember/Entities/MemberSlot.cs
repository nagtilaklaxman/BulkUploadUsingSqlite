namespace Core.ESanjeevani.InstituteMember.Entities
{
    public class MemberSlot
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Day { get; set; }
        public string SlotTo { get; set; }
        public string SlotFrom { get; set; }
        public string CreatedDate { get; set; }
        public string IsActive { get; set; }
        public string SourceId { get; set; }

    }
}

