using Domain.Common.interfaces.Repository;
using Domain.ESanjeevani.InstituteMember.Entities;

namespace Domain.ESanjeevani.InstituteMember.Repository
{
    public interface IInstituteMemberBulkEntityRepository : IRepository<InstituteMemberBulkEntity>
    {
        public string Connectionstring { get;  }
    }
}

