using System.Data;
using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Repositories;
using Domain.Common.interfaces.Repository;

namespace Domain.ESanjeevani.InstituteMember.Repository;

public interface IStateDistrictCityRepository : IRepository<StateDistrictCity>
{
    Task<IReadOnlyList<KeyValuePair<int, string>>?> GetAllStates();
    Task<IReadOnlyList<KeyValuePair<int, string>>?> GetDistrictsByStateId(int stateId);
    Task<IReadOnlyList<KeyValuePair<int, string>>?> GetCitiesByDistrictId(int districtId);
}

public interface IUnitOfWork
{
    public Task<bool> SetSession(string sessionId);
    public IInstituteMemberBulkEntityRepository BulkEntities { get; }
}