using Core.ESanjeevani.InstituteMember.Entities;
using FluentMigrator;

namespace Infrastructure.Migrations.Fluent.ESanjeevani.InstituteMember
{
    public class AddAuditTrailTable : Migration
    {
        public AddAuditTrailTable()
        {
        }

        public override void Down()
        {
            var auditTrail = new AuditTrail();
            var tblName = auditTrail.GetType().Name + "s";
            Delete.Table(tblName);

        }

        public override void Up()
        {
            var auditTrail = new AuditTrail();
            var tblName = auditTrail.GetType().Name + "s";

            Create.Table(tblName)
              .WithColumn(nameof(auditTrail.Id)).AsInt64().PrimaryKey().Identity()
              .WithColumn(nameof(auditTrail.AccessType)).AsString()
              .WithColumn(nameof(auditTrail.CreatedDate)).AsDateTime()
              .WithColumn(nameof(auditTrail.EventId)).AsString()
              .WithColumn(nameof(auditTrail.IconPath)).AsString()
              .WithColumn(nameof(auditTrail.LocationIPAddress)).AsString()
              .WithColumn(nameof(auditTrail.MemberId)).AsString()
              .WithColumn(nameof(auditTrail.Message)).AsString()
              .WithColumn(nameof(auditTrail.ModuleId)).AsString()
              .WithColumn(nameof(auditTrail.SourceId)).AsString()
              .WithColumn(nameof(auditTrail.UserTypeId)).AsString()


              .WithColumn("LocalDbRecordId").AsInt64();
        }
    }
}


