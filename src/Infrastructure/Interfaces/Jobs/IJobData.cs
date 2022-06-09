using System;
using System.Data;
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

    public interface IJobConnectionFactory
    {
        public IDbConnection Connection { get;}
    }
}

