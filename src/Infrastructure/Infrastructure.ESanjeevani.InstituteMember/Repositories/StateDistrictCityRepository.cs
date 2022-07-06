using System.Data;
using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Repository;
using Dapper;
using Domain.Common.Entities;

namespace Infrastructure.ESanjeevani.InstituteMember.Repositories;

public class StateDistrictCityRepository : IStateDistrictCityRepository
{
    private readonly IDbConnection _connection;

    private readonly  Dictionary<string, string> _stateAndCodes = new()
    {
        {"ANDHRA PRADESH","AP"},
        {"ARUNACHAL PRADESH","AR"},
        {"ASSAM","AS"},
        {"BIHAR","BR"},
        {"CHHATTISGARH","CG"},
        {"DELHI","DL"},
        {"GOA","GA"},
        {"GUJARAT","GJ"},
        {"HARYANA","HR"},
        {"HIMACHAL PRADESH","HP"},
        {"JAMMU & KASHMIR","JK"},
        {"JHARKHAND","JH"},
        {"KARNATAKA","KA"},
        {"KERALA","KL"},
        {"MADHYA PRADESH","MP"},
        {"MAHARASHTRA","MH"},
        {"MANIPUR","MN"},
        {"MEGHALAYA","MG"},
        {"MIZORAM","MZ"},
        {"NAGALAND","NL"},
        {"ORISSA","OR"},
        {"PUNJAB","PB"},
        {"RAJASTHAN","RJ"},
        {"SIKKIM","SK"},
        {"TAMIL NADU","TN"},
        {"TRIPURA","TR"},
        {"TELANGANA","TS" },
        {"UTTARAKHAND","UK"},
        {"UTTAR PRADESH","UP"},
        {"WEST BENGAL","WB"},
        {"ANDAMAN & NICOBAR","AN"},
        {"CHANDIGARH","CH"},
        {"DADRA AND NAGAR HAVELI","DN"},
        {"DAMAN & DIU","DD"},
        {"LAKSHADWEEP","LD"},
        {"PONDICHERRY","PY"},
        {"PUDUCHERRY","PY"},
        {"ODISHA","OR"},
        {"DADRA AND NAGAR HAVELI AND DAMAN AND DIU","DN"}

    };

    public StateDistrictCityRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public Task<StateDistrictCity> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
    public async Task<IReadOnlyList<KeyValuePair<int, string>>?> GetAllStates()
    {
        var sql = "SELECT S.StateId AS Key, S.StateName AS Value" +
                  " FROM md_state AS S " +
                  " WHERE S.CountryId = 1 Order by S.StateName; ";
        var result = await _connection.QueryAsync<KeyValuePair<int, string>>(sql);
        return result?.ToList();
    }

    public async Task<IReadOnlyList<KeyValuePair<int, string>>?> GetDistrictsByStateId(int stateId)
    {
       
        var sql = $@"SELECT D.DistrictId AS Key, D.DistrictName AS Value 
                   FROM  md_district AS D
                   WHERE D.StateId = {stateId} Order by D.DistrictName; ";
        var result = await _connection.QueryAsync<KeyValuePair<int, string>>(sql);
        return result?.ToList();
    }

    public async Task<IReadOnlyList<KeyValuePair<int, string>>?> GetCitiesByDistrictId(int districtId)
    {
        var sql = $@"SELECT C.CityId AS Key, C.CityName AS Value 
                    FROM md_city AS C 
                    WHERE C.DistrictId = {districtId} Order by C.CityName; ";
        var result = await _connection.QueryAsync<KeyValuePair<int, string>>(sql);
        return result?.ToList();
    }
    public async Task<IReadOnlyList<StateDistrictCity>> GetAllAsync()
    {
        var sql = @"SELECT S.StateId, S.StateName,S.StateCode 
                  ,D.DistrictId, D.DistrictName 
                  , (SELECT ShortDistCode FROM lgd_dist AS L WHERE L.DistrictNameE = D.DistrictName LIMIT 1) AS DistrictShortCode 
                  , C.CityId, C.CityName, C.CityCode
                   FROM md_state AS S
                   JOIN md_district AS D ON S.StateId = D.StateId 
                   JOIN md_city AS C ON C.DistrictId = D.DistrictId 
                   WHERE S.CountryId = 1; ";
        
        var results = await _connection.QueryAsync<StateDistrictCity>(sql);
        if (results is null || results.Count() <= 0) return new List<StateDistrictCity>();

        foreach (var item in results)
        {
            item.StateShortCode = _stateAndCodes.FirstOrDefault(t =>
                    string.Equals(t.Key, item.StateName, StringComparison.InvariantCultureIgnoreCase))
                .Value;
        }

        return results.ToList();
    }

    public  Task<int> AddAsync(StateDistrictCity entity)
    {
        throw new NotImplementedException();
    }

    public  Task<int> UpdateAsync(StateDistrictCity entity)
    {
        throw new NotImplementedException();
    }

    public  Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddRangeAsync(IList<StateDistrictCity> entities)
    {
        throw new NotImplementedException();
    }

    public  Task<int> DeleteRangeAsync(IList<int> ids)
    {
        throw new NotImplementedException();
    }

    public Task<PagedEntity<StateDistrictCity>> GetPagedDataAsync(int page, int records)
    {
        throw new NotImplementedException();
    }
}