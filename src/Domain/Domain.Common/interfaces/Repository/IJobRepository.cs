using Domain.Common.Entities;

namespace Domain.Common.interfaces.Repository;

public interface IJobRepository : IRepository<JobRecord>
{
    public Task<IReadOnlyList<JobRecord>> GetPendingJobs(int numberOfJobsToFetch);
    public Task<IReadOnlyList<JobRecord>> GetAllPendingJobs();
}