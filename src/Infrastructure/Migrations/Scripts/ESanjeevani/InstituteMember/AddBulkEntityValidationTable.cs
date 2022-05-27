using Infrastructure.Interfaces.Migrations;

namespace Infrastructure.Migrations.Scripts.ESanjeevani.InstituteMember
{
    public class AddBulkEntityValidationTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddBulkEntityValidationTable()
        {
            _sql = @"
                   CREATE TABLE if not exists BulkEntityValidations (
                    Id           INTEGER  NOT NULL
                                          PRIMARY KEY AUTOINCREMENT,
                    BulkEntityId INTEGER  NOT NULL,
                    CreatedDate  DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP),
                    DeletedDate  DATETIME ,
                    ErrorMessage TEXT     NOT NULL,
                    IsDeleted    INTEGER  NOT NULL DEFAULT (0),
                    PropertyName TEXT     NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
}

