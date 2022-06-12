using Domain.ESanjeevani.InstituteMember.Entities;
using Infrastructure.Common.Interfaces;
using Infrastructure.ESanjeevani.InstituteMember.FileHelper;

namespace Infrastructure.ESanjeevani.InstituteMember;

public class ExcelEntityToBulkEntity : IMapper<InstituteMemberExcelEntity, InstituteMemberBulkEntity>
{
    public ExcelEntityToBulkEntity()
    {
        //need to inject mysql repos    
    }
    public Task<InstituteMemberBulkEntity> Map(InstituteMemberExcelEntity source)
    {
        var obj = new InstituteMemberBulkEntity
        {
            AssignedInstituteID = source.AssignedInstituteID,
            UserDistrictShortCode = string.Empty, // need to implement it
            DOB = source.DOB,
            UserStateId = GetStateId(source.UserStateName),
            UserDistrictId = GetDistrictId(source.UserDistrictName,
                source.UserStateName),
            UserCityId = GetCityId(source.UserCityName,
                source.UserDistrictName,
                source.UserStateName),
            UserAddress = source.UserAddress,
            UserPin = source.UserPin,
            UserPrefix = source.UserPrefix,
            UserAvailableDay = source.UserAvailableDay,
            UserAvailableFromTime = source.UserAvailableFromTime,
            UserAvailableToTime = source.UserAvailableToTime,
            UserRole = source.UserRole,
            SubMenuNames = source.SubMenuNames,
            DRRegNo = source.DRRegNo,
            UserEmail = source.UserEmail,
            SpecialityId = GetSpecialityId(source.SpecialityName),
            Experience = source.Experience,
            HFAddress = source.HFAddress,
            HFCityId = GetCityId(source.HFCityName,
                source.HFDistrictName,
                source.HFStateName),
            HFDistrictId = GetDistrictId(source.HFDistrictName,
                source.HFStateName),
            HFEmail = source.HFEmail,
            UserFirstName = source.UserFirstName,
            UserLastName = source.UserLastName,
            UserMobile = source.UserMobile,
            UserGenderId = GetGenderId(source.UserGenderName),
            QualificationId = GetQualificationId(source.QualificationName),
            HFPhone = source.HFPhone,
            HFTypeId = GetHFTypeId(source.HFTypeName),
            NIN = source.NIN,
            HFStateId = GetStateId(source.HFStateName),
            HFPIN = source.HFPIN,
            HFName = source.HFName,
            HFShortName = source.HFShortName,
        };
        return Task.FromResult(obj);
    }
    private int GetSpecialityId(string specialityName)
    {
        return 0;
    }
    private int GetCityId(string cityName,string districtName, string stateName)
    {
        return 0;
    }
    private int GetDistrictId(string districtName, string stateName)
    {
        return 0;
    }
    private int GetStateId(string stateName)
    {
        return 0;
    }

    private int GetHFTypeId(string hfType)
    {
        return 0;
    }
    private int GetGenderId(string genderName)
    {
        return 0;
    }

    private int GetQualificationId(string qualificationName)
    {
        return 0;
    }

    public async Task<IEnumerable<InstituteMemberBulkEntity>> Map(IEnumerable<InstituteMemberExcelEntity> sourceRecords)
    {
        List<InstituteMemberBulkEntity> bulkEntities = new();
        foreach (var item in sourceRecords)
        {
            bulkEntities.Add(await Map(item));
        }

        return bulkEntities;
    }
}