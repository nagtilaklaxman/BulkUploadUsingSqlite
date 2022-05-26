using Core.ESanjeevani.InstituteMember.Entities;
using FluentMigrator;

namespace Infrastructure.Migrations.Fluent.ESanjeevani.InstituteMember
{
    public class AddInstitutionMemberTable : Migration
    {
        public AddInstitutionMemberTable()
        {
        }

        public override void Down()
        {
            var institutionMember = new InstitutionMember();
            var tblName = institutionMember.GetType().Name + "s";
            Delete.Table(tblName);

        }

        public override void Up()
        {
            var institutionMember = new InstitutionMember();
            var tblName = institutionMember.GetType().Name + "s";

            Create.Table(tblName)
              .WithColumn(nameof(institutionMember.Id)).AsInt64().PrimaryKey().Identity()
              .WithColumn(nameof(institutionMember.IsActive)).AsString()
              .WithColumn(nameof(institutionMember.InstitutionId)).AsString()
              .WithColumn(nameof(institutionMember.MemberId)).AsInt64()
              .WithColumn(nameof(institutionMember.SourceId)).AsString()

              .WithColumn("CreatedDate").AsDateTime().WithDefaultValue(DateTime.UtcNow)
              .WithColumn("LocalDbRecordId").AsInt64();
        }
    }
}


