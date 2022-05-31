using System;
using Infrastructure.Interfaces.Jobs;

namespace Infrastructure.Jobs
{
    public class JobRecord
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ModuleName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; }
        public string JsonData { get; set; } // this is jsonData of IJobData<T>
    }
    public class JobProcessor : IJobProcessor
    {
        public Task Process(CancellationToken cancellationToken)
        {
            // read not completed jobs from DB and fires event for module to handle it
            return Task.CompletedTask;
        }
    }
}

