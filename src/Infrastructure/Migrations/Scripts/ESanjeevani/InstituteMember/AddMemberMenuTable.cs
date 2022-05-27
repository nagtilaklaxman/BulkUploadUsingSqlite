using Infrastructure.Interfaces.Migrations;

namespace Infrastructure.Migrations.Scripts.ESanjeevani.InstituteMember
{
    public class AddMemberMenuTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddMemberMenuTable()
        {
            _sql = @"
                   CREATE TABLE if not exists MemberMenus (
                    MemberMenuId    INTEGER  NOT NULL  PRIMARY KEY AUTOINCREMENT,
                    Id              INTEGER  NOT NULL  DEFAULT (0),
                    IsActive        TEXT     ,
                    InstitutionId   INTEGER  NOT NULL  DEFAULT (0),
                    MemberId        INTEGER  NOT NULL  DEFAULT (0),
                    MenuMappingId   INTEGER  NOT NULL  DEFAULT (0),
                    RoleId          TEXT     ,
                    SourceId        TEXT     ,
                    CreatedDate     DATETIME NOT NULL
                                             DEFAULT (CURRENT_TIMESTAMP),
                    BulkEntityId    INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
}

