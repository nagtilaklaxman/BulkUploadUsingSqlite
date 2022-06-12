namespace Domain.ESanjeevani.InstituteMember.Entities;

public class StateDistrictCity
{
    public int StateId { get; set; }
    public string StateName { get; set; }
    public int StateCode { get; set; }
    public string StateShortCode { get; set; }
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }
    public string  DistrictCode { get; set; }
    public string DistrictShortCode { get; set; }
    public int CityId { get; set; }
    public string CityName { get; set; }
    public int CityCode { get; set; }
}