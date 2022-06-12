using Domain.ESanjeevani.InstituteMember.Migrations;

namespace Infrastructure.ESanjeevani.InstituteMember.Migrations
{
    public class AddLoginTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddLoginTable()
        {
            _sql = @"
                    CREATE TABLE if not exists Logins (
                    LoginId         INTEGER  NOT NULL  PRIMARY KEY AUTOINCREMENT,
                    Id              INTEGER  NOT NULL  DEFAULT (0),
                    IsActive        TEXT     ,
                    Password        TEXT     NOT NULL,
                    ReferenceId     INTEGER  NOT NULL,
                    SourceId        TEXT     ,
                    UserName        TEXT     NOT NULL,
                    CreatedDate     DATETIME NOT NULL
                                             DEFAULT (CURRENT_TIMESTAMP),
                    BulkEntityId    INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
}

