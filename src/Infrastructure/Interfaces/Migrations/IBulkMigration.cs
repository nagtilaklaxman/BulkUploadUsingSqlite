using System;
namespace Infrastructure.Interfaces.Migrations
{
    public interface IBulkMigration
    {
        string MigrationSql { get; }
    }
}

