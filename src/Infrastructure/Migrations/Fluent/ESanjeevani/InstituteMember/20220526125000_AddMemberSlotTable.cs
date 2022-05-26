using Core.ESanjeevani.InstituteMember.Entities;
using FluentMigrator;

namespace Infrastructure.Migrations.Fluent.ESanjeevani.InstituteMember
{
    [Migration(20220526125000)]
    public class AddMemberSlotTable : Migration
    {
        public AddMemberSlotTable()
        {
        }

        public override void Down()
        {
            var memberSlot = new MemberSlot();
            var tblName = memberSlot.GetType().Name + "s";
            Delete.Table(tblName);

        }

        public override void Up()
        {
            var memberSlot = new MemberSlot();
            var tblName = memberSlot.GetType().Name + "s";

            Create.Table(tblName)
              .WithColumn(nameof(memberSlot.Id)).AsInt64().PrimaryKey().Identity()
              .WithColumn(nameof(memberSlot.IsActive)).AsString()
              .WithColumn(nameof(memberSlot.Day)).AsString()
              .WithColumn(nameof(memberSlot.MemberId)).AsInt64()
              .WithColumn(nameof(memberSlot.CreatedDate)).AsDateTime()
              .WithColumn(nameof(memberSlot.SlotFrom)).AsString()
              .WithColumn(nameof(memberSlot.SlotTo)).AsString()
              .WithColumn(nameof(memberSlot.SourceId)).AsString()


              .WithColumn("LocalDbRecordId").AsInt64();
        }
    }
}


