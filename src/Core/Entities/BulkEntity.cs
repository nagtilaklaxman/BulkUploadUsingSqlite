using CSharpFunctionalExtensions;

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

    public sealed class BulkError : ValueObject
    {
        private const string Separator = "||";

        public string Code { get; }
        public string Message { get; }

        internal BulkError(string code, string message)
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

    public static class Errors
    {
        public static class Institute
        {

            public static BulkError AlreadyRegistered(string instituteName) =>
                new BulkError("institute.already.enrolled", $"institute is already registered '{instituteName}'");

            public static BulkError EmailIsTaken() =>
                new BulkError("institute.email.is.taken", "Institute email is taken");
        }
        public static class User
        {

            public static BulkError AlreadyRegistered(string userName) =>
                new BulkError("institute.already.enrolled", $"user is already registered '{userName}'");

            public static BulkError EmailIsTaken() =>
                new BulkError("user.email.is.taken", "User email is taken");
        }

        public static class File
        {
            public static BulkError Empty()
            {
                return new BulkError("file.is.empty", $"file is empty");
            }
            public static BulkError TooSmall(string fileSize)
            {
                return new BulkError(
                    "file.is.too.small",
                    $"The file is less than {fileSize}.");
            }
            public static BulkError TooLarge(string fileSize)
            {
                return new BulkError(
                    "file.is.too.large",
                    $"The file is larger than {fileSize}.");
            }
            public static BulkError NotSupportedType(string message = "This file type is not supported")
            {
                return new BulkError("file.type.not.supported", message);
            }
            public static BulkError InvalidTemplate()
            {
                return new BulkError("file.template.invalid", "Invalid file template provided");
            }
        }
        public static class General
        {

            public static BulkError NotFound(long? id = null)
            {
                string forId = id == null ? "" : $" for Id '{id}'";
                return new BulkError("record.not.found", $"Record not found{forId}");
            }

            public static BulkError ValueIsInvalid() =>
                new BulkError("value.is.invalid", "Value is invalid");

            public static BulkError ValueIsRequired() =>
                new BulkError("value.is.required", "Value is required");

            public static BulkError InvalidLength(string name = null)
            {
                string label = name == null ? " " : " " + name + " ";
                return new BulkError("invalid.string.length", $"Invalid{label}length");
            }

            public static BulkError CollectionIsTooSmall(int min, int current)
            {
                return new BulkError(
                    "collection.is.too.small",
                    $"The collection must contain {min} items or more. It contains {current} items.");
            }

            public static BulkError CollectionIsTooLarge(int max, int current)
            {
                return new BulkError(
                    "collection.is.too.large",
                    $"The collection must contain {max} items or more. It contains {current} items.");
            }

            public static BulkError InternalServerError(string message)
            {
                return new BulkError("internal.server.error", message);
            }
        }
    }
}

