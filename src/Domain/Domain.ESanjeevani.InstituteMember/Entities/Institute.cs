namespace Domain.ESanjeevani.InstituteMember.Entities
{
    public class Institute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string ReferenceNumber { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int CityId { get; set; }
        public string PinCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string InstitutionTypeId { get; set; }
        public string IsActive { get; set; }
        public string Fax { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string SourceId { get; set; }
        public string StatusIdpublic { get; set; }

        /// <summary>
        /// mapping with member table
        /// </summary>
        public IList<InstitutionMember> Members { get; set; }

    }
}

