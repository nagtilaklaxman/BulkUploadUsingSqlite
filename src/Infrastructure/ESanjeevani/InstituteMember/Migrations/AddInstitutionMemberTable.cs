using Infrastructure.Interfaces.Migrations;

namespace Infrastructure.ESanjeevani.InstituteMember.Migrations
{
    public class AddInstitutionMemberTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddInstitutionMemberTable()
        {
            _sql = @"
                    CREATE TABLE if not exists InstitutionMembers (
                    InstitutionMemberId   INTEGER  NOT NULL  PRIMARY KEY AUTOINCREMENT,
                    Id                    INTEGER  NOT NULL  DEFAULT (0),
                    IsActive              TEXT     ,
                    InstitutionId         INTEGER  NOT NULL  DEFAULT (0),
                    MemberId              INTEGER  NOT NULL  DEFAULT (0),
                    SourceId              TEXT     ,
                    CreatedDate           DATETIME NOT NULL  DEFAULT (CURRENT_TIMESTAMP),
                    BulkEntityId          INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
}

