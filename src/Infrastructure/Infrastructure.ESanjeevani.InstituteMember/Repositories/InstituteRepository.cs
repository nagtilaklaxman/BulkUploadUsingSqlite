using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Repository;

namespace Infrastructure.ESanjeevani.InstituteMember.Repositories
{
    public class InstituteRepository : IInstituteRepository
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

    public class InstituteWithLoggerRepository : IInstituteRepository
    {
        private readonly IInstituteRepository _instituteRepository;

        public InstituteWithLoggerRepository(IInstituteRepository instituteRepository)
        {
            this._instituteRepository = instituteRepository;
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

