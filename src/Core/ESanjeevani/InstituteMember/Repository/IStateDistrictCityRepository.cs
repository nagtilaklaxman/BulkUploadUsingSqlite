using System.Data;
using Core.ESanjeevani.InstituteMember.Entities;
using Core.interfaces.Repository;

namespace Core.ESanjeevani.InstituteMember.Repository;

public interface IStateDistrictCityRepository : IRepository<StateDistrictCity>
{
    Task<IReadOnlyList<KeyValuePair<int, string>>?> GetAllStates();
    Task<IReadOnlyList<KeyValuePair<int, string>>?> GetDistrictsByStateId(int stateId);
    Task<IReadOnlyList<KeyValuePair<int, string>>?> GetCitiesByDistrictId(int districtId);
}