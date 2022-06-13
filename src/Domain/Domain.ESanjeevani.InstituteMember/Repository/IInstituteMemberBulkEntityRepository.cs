using Domain.Common.Entities;
using Domain.Common.interfaces.Repository;
using Domain.ESanjeevani.InstituteMember.Entities;

namespace Domain.ESanjeevani.InstituteMember.Repository
{
    public interface IInstituteMemberBulkEntityRepository : IRepository<InstituteMemberBulkEntity>
    {
        public string Connectionstring { get;  }

        public Task<int> AddBulkEntityValidations(IEnumerable<BulkEntityValidation> validations);
        public Task<int> DeleteBulkEntityValidations(IEnumerable<BulkEntityValidation> validations);
    }
}

