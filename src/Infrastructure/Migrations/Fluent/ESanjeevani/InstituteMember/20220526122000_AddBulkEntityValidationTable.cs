using Core.Entities;
using FluentMigrator;

namespace Infrastructure.Migrations.Fluent.ESanjeevani.InstituteMember
{
    [Migration(20220526122000)]
    public class AddBulkEntityValidationTable : Migration
    {
        public AddBulkEntityValidationTable()
        {
        }

        public override void Down()
        {
            var bulkEntityValidation = new BulkEntityValidation();
            var tblName = bulkEntityValidation.GetType().Name + "s";
            Delete.Table(tblName);

        }

        public override void Up()
        {
            var bulkEntityValidation = new BulkEntityValidation();
            var tblName = bulkEntityValidation.GetType().Name + "s";

            Create.Table(tblName)
              .WithColumn(nameof(bulkEntityValidation.Id)).AsInt64().PrimaryKey().Identity()
              .WithColumn(nameof(bulkEntityValidation.BulkEntityId)).AsInt64()
              .WithColumn(nameof(bulkEntityValidation.CreatedDate)).AsDateTime()
              .WithColumn(nameof(bulkEntityValidation.DeletedDate)).AsDateTime()
              .WithColumn(nameof(bulkEntityValidation.ErrorMessage)).AsString()
              .WithColumn(nameof(bulkEntityValidation.IsDeleted)).AsBoolean()
              .WithColumn(nameof(bulkEntityValidation.PropertyName)).AsString();

        }
    }
}


