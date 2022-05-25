namespace Core.ESanjeevani.InstituteMember.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AgeType { get; set; }
        public DateTime DOB { get; set; }
        public string Age { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string IsActive { get; set; }
        public int GenderId { get; set; }
        public string RegistrationNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public int SpecializationId { get; set; }
        public int QualificationId { get; set; }
        public string PinCode { get; set; }
        public string Fax { get; set; }
        public string LoginOTP { get; set; }
        public string IsLoginOTPActive { get; set; }
        public string SignaturePath { get; set; }
        public int CountryId { get; set; }
        public string StatusId { get; set; }
        public string RatingMasterId { get; set; }
        public string SourceId { get; set; }
        public bool IsMaster { get; set; } = false;  // Master user for institute
        public string ImagePath { get; set; }
        public string FileName { get; set; }
        public string FileFlag { get; set; }
        public string IsAvailable { get; set; }
        public string Prefix { get; set; }
        public string CreationRolepublic { get; set; }

        /// <summary>
        /// Mapping between Models
        /// </summary>
        public IList<MemberMenu> MemberMenus { get; set; }
        public IList<InstitutionMember> Institutions { get; set; }
        public IList<MemberSlot> Slots { get; set; }
    }
}

