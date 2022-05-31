using System;
using Infrastructure.Jobs;

namespace Infrastructure.Interfaces.Jobs
{
    public interface IJobData<T> where T : class
    {
        //marker for job data
    }
    public interface IJobProcessor
    {
        Task Process(CancellationToken cancellationToken);
    }
}

