using Core.ESanjeevani.InstituteMember.Entities;
using FluentMigrator;

namespace Infrastructure.Migrations.Fluent.ESanjeevani.InstituteMember
{
    [Migration(20220526124500)]
    public class AddMemberMenuTable : Migration
    {
        public AddMemberMenuTable()
        {
        }

        public override void Down()
        {
            var memberMenu = new MemberMenu();
            var tblName = memberMenu.GetType().Name + "s";
            Delete.Table(tblName);

        }

        public override void Up()
        {
            var memberMenu = new MemberMenu();
            var tblName = memberMenu.GetType().Name + "s";

            Create.Table(tblName)
              .WithColumn(nameof(memberMenu.Id)).AsInt64().PrimaryKey().Identity()
              .WithColumn(nameof(memberMenu.IsActive)).AsString()
              .WithColumn(nameof(memberMenu.InstitutionId)).AsInt64()
              .WithColumn(nameof(memberMenu.MemberId)).AsInt64()
              .WithColumn(nameof(memberMenu.MenuMappingId)).AsInt64()
              .WithColumn(nameof(memberMenu.RoleId)).AsString()
              .WithColumn(nameof(memberMenu.SourceId)).AsString()

              .WithColumn("CreatedDate").AsDateTime().WithDefaultValue(DateTime.UtcNow)
              .WithColumn("LocalDbRecordId").AsInt64();
        }
    }
}


