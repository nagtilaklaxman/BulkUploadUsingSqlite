using System;
using Infrastructure.Common.Jobs;

namespace Infrastructure.Common.Interfaces.Jobs
{
    public interface IJobProcessor
    {
        Task Process(CancellationToken cancellationToken);
    }
}

