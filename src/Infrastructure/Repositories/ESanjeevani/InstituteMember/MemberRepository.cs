using Core.ESanjeevani.InstituteMember.Entities;
using Core.ESanjeevani.InstituteMember.Repositories;

namespace Infrastructure.Repositories.ESanjeevani.InstituteMember
{
    public class MemberRepository : IMemberRepository
    {
        public Task<int> AddAsync(Member entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddRangeAsync(IList<Member> entity)
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

        public Task<int> AddRangeAsync(IList<Member> entity)
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

