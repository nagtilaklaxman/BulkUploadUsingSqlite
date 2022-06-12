namespace Domain.Common.Entities
{
    public class BulkEntityValidation
    {
        public int Id { get; set; }
        public int BulkEntityId { get; set; } // ForeignKey for BulkEntity
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public DateTime DeletedDate { get; set; }
    }
}

