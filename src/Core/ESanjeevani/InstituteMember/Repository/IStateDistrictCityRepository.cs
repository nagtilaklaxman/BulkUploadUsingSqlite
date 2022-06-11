using System.Data;
using Core.ESanjeevani.InstituteMember.Entities;
using Core.ESanjeevani.InstituteMember.Repositories;
using Core.interfaces.Repository;

namespace Core.ESanjeevani.InstituteMember.Repository;

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
    public IInstituteRepository Institutes { get;}
    public IMemberRepository Members { get;}
}