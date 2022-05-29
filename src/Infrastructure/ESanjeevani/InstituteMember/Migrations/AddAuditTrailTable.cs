using Infrastructure.Interfaces.Migrations;

namespace Infrastructure.ESanjeevani.InstituteMember.Migrations
{
    public class AddAuditTrailTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddAuditTrailTable()
        {
            _sql = @"
                   CREATE TABLE if not exists AuditTrails (
                    AuditTrailId      INTEGER  NOT NULL  PRIMARY KEY AUTOINCREMENT,
                    Id                INTEGER  NOT NULL   DEFAULT (0),
                    AccessType        TEXT     ,
                    CreatedDate       DATETIME ,
                    EventId           TEXT     ,
                    IconPath          TEXT     ,
                    LocationIPAddress TEXT     ,
                    MemberId          TEXT     ,
                    Message           TEXT     ,
                    ModuleId          TEXT     ,
                    SourceId          TEXT     ,
                    UserTypeId        TEXT     ,
                    BulkEntityId      INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
}

