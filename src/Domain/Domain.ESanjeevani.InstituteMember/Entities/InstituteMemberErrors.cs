using Domain.Common.Entities;

namespace Domain.ESanjeevani.InstituteMember.Entities;

public static class InstituteMemberErrors
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
        public static BulkError AlreadyRegistered(string instituteName) =>
            new BulkError("institute.already.enrolled", $"institute is already registered '{instituteName}'");

        public static BulkError EmailIsTaken() =>
            new BulkError("user.email.is.taken", "User email is taken");
    }
}