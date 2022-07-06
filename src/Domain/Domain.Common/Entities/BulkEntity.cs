using CSharpFunctionalExtensions;

namespace Domain.Common.Entities
{
    public abstract class BulkEntity
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }
        public bool IsDelted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public IList<BulkEntityValidation> Validations { get; set; } = new List<BulkEntityValidation>(); // this should be the readonly

        public bool Delete()
        {
            this.IsDelted = true;
            this.DeletedDate = DateTime.UtcNow;
            return true;
        }
    }

    public sealed class BulkError : ValueObject
    {
        private const string Separator = "||";

        public string Code { get; }
        public string Message { get; }

        public BulkError(string code, string message)
        {
            Code = code;
            Message = message;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }

        public string Serialize()
        {
            return $"{Code}{Separator}{Message}";
        }

        public static BulkError Deserialize(string serialized)
        {
            if (serialized == "A non-empty request body is required.")
                return Errors.General.ValueIsRequired();

            string[] data = serialized.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);

            if (data.Length < 2)
                throw new Exception($"Invalid error serialization: '{serialized}'");

            return new BulkError(data[0], data[1]);
        }
    }

    public class PagedEntity<T> where T : class
    {
        public int Page { get; set; }
        public int Records { get; set; }
        public int Total { get; set; }
        public IList<T> Data { get; set; }
    }
}

