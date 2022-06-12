namespace Domain.Common.Entities;

public static class Errors
{ 
    public static class Institute
    {
        public static BulkError AlreadyRegistered(string instituteName) =>
            new BulkError("institute.already.enrolled", $"institute is already registered '{instituteName}'");
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

        public static BulkError InvalidLength(string? name)
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
        public static BulkError EmailAlreadyExists() =>
            new BulkError("email.already.exists", "email is already exists");
        
        public static BulkError PhoneAlreadyExists() =>
            new BulkError("phone.already.exists", "phone number is already exists");
        
        public static BulkError InternalServerError(string message)
        {
            return new BulkError("internal.server.error", message);
        }
    }
}