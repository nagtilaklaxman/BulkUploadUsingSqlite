namespace Core.ESanjeevani.InstituteMember.Entities
{
    public class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ReferenceId { get; set; } // foreign key of Id from member table
        public string IsActive { get; set; }
        public string SourceId { get; set; }

        //Member login
        public Member Member { get; set; }
    }
}

