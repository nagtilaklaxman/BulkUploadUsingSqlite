using Domain.Common.Entities;
using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Repositories;

namespace Infrastructure.ESanjeevani.InstituteMember.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public Task<int> AddAsync(Member entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRangeAsync(IList<Member> entities)
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

        public Task<PagedEntity<Member>> GetPagedDataAsync(int page, int records)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Member>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Member> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Member entity)
        {
            throw new NotImplementedException();
        }
    }
    public class MemberWithLoggerRepository : IMemberRepository
    {
        private readonly IMemberRepository _memberRepository;

        public MemberWithLoggerRepository(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public Task<int> AddAsync(Member entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRangeAsync(IList<Member> entities)
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

        public Task<PagedEntity<Member>> GetPagedDataAsync(int page, int records)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Member>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Member> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Member entity)
        {
            throw new NotImplementedException();
        }
    }
}

