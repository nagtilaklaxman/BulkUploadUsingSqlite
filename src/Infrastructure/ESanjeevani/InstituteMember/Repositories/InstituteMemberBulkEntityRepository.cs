using System;
using Core.ESanjeevani.InstituteMember.Entities;
using Core.ESanjeevani.InstituteMember.Repositories;

namespace Infrastructure.ESanjeevani.InstituteMember.Repositories
{
    public class InstituteMemberBulkEntityRepository : IInstituteMemberBulkEntityRepository
    {
        public Task<int> AddAsync(InstituteMemberBulkEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRangeAsync(IList<InstituteMemberBulkEntity> entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteRangeAsync(IList<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<InstituteMemberBulkEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InstituteMemberBulkEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(InstituteMemberBulkEntity entity)
        {
            throw new NotImplementedException();
        }
    }

}

