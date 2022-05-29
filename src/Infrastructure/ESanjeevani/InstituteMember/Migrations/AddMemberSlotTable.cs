using Infrastructure.Interfaces.Migrations;

namespace Infrastructure.ESanjeevani.InstituteMember.Migrations
{
    public class AddMemberSlotTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddMemberSlotTable()
        {
            _sql = @"
                    CREATE TABLE if not exists MemberSlots (
                    MemberSlotId    INTEGER  NOT NULL  PRIMARY KEY AUTOINCREMENT,
                    Id              INTEGER  NOT NULL  DEFAULT (0),
                    IsActive        TEXT     ,
                    Day             TEXT     ,
                    MemberId        INTEGER  NOT NULL  DEFAULT (0),
                    CreatedDate     DATETIME NOT NULL  DEFAULT (CURRENT_TIMESTAMP),
                    SlotFrom        TEXT     ,
                    SlotTo          TEXT     ,
                    SourceId        TEXT     ,
                    BulkEntityId    INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
}

