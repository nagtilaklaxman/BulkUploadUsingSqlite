
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
    }
}

