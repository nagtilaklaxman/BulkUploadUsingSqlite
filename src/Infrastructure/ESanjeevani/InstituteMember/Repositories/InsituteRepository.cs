using Core.ESanjeevani.InstituteMember.Entities;
using Core.ESanjeevani.InstituteMember.Repositories;
using Core.ESanjeevani.InstituteMember.Repository;

namespace Infrastructure.ESanjeevani.InstituteMember.Repositories
{
    public class InsituteRepository : IInsituteRepository
    {
        public Task<int> AddAsync(Institute entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRangeAsync(IList<Institute> entities)
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

        public Task<IReadOnlyList<Institute>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Institute> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Institute entity)
        {
            throw new NotImplementedException();
        }
    }

    public class InsituteWithLoggerRepository : IInsituteRepository
    {
        private readonly IInsituteRepository _insituteRepository;

        public InsituteWithLoggerRepository(IInsituteRepository insituteRepository)
        {
            this._insituteRepository = insituteRepository;
        }
        public Task<int> AddAsync(Institute entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRangeAsync(IList<Institute> entities)
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

        public Task<IReadOnlyList<Institute>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Institute> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Institute entity)
        {
            throw new NotImplementedException();
        }
    }

}

