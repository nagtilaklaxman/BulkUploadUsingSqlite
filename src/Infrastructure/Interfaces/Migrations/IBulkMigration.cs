using System;
namespace Infrastructure.Interfaces.Migrations
{
    public interface IBulkMigration
    {
        string GetMigrationSql();
    }
    public interface IInstituteMemberMigration : IBulkMigration
    {

    }
}

