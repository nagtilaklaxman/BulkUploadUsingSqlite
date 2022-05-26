using Core.ESanjeevani.InstituteMember.Entities;
using FluentMigrator;

namespace Infrastructure.Migrations.Fluent.ESanjeevani.InstituteMember
{
    [Migration(20220526124000)]
    public class AddLoginTable : Migration
    {
        public AddLoginTable()
        {
        }

        public override void Down()
        {
            var institute = new Login();
            var tblName = institute.GetType().Name + "s";
            Delete.Table(tblName);

        }

        public override void Up()
        {
            var login = new Login();
            var tblName = login.GetType().Name + "s";

            Create.Table(tblName)
              .WithColumn(nameof(login.Id)).AsInt64().PrimaryKey().Identity()
              .WithColumn(nameof(login.IsActive)).AsString()
              .WithColumn(nameof(login.Password)).AsString()
              .WithColumn(nameof(login.ReferenceId)).AsInt64()
              .WithColumn(nameof(login.SourceId)).AsString()
              .WithColumn(nameof(login.UserName)).AsString()

              .WithColumn("CreatedDate").AsDateTime().WithDefaultValue(DateTime.UtcNow)
              .WithColumn("LocalDbRecordId").AsInt64();
        }
    }
}


