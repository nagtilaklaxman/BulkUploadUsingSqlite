namespace Core.Entities
{
    public abstract class BulkEntity
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
        public bool IsDelted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public IList<BulkEntityValidation> Validations { get; set; } // this should be the readonly

        public bool Delete()
        {
            this.IsDelted = true;
            this.DeletedDate = DateTime.UtcNow;
            return true;
        }
    }
}

