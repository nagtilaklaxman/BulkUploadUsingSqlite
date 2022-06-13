
using Newtonsoft.Json;

namespace Domain.Common.Entities
{
    public class JobRecord
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string SessionId { get; set; }  
        public string ModuleName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public string JobData { get; set; } // this is jsonData of every module
        public bool IsCompleted { get; set; } = false;

        public bool SetJobData<T>(T data) where T : new()
        {
            if (data != null) this.JobData = JsonConvert.SerializeObject(data);
            return true;
        }

        public T GetJobData<T>() where T:new()
        {
            if (!string.IsNullOrWhiteSpace(JobData))
            {
                return JsonConvert.DeserializeObject<T>(JobData) ?? new T();
            }

            return new T();
        }
    }
}

