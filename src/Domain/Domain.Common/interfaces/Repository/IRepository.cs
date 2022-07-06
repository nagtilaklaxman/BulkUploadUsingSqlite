using Domain.Common.Entities;

namespace Domain.Common.interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<int> AddRangeAsync(IList<T> entities);
        Task<int> DeleteRangeAsync(IList<int> ids);
        Task<PagedEntity<T>> GetPagedDataAsync(int page, int records) ;
    }
}

