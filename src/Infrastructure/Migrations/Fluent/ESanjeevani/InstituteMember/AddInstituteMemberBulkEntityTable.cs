using Core.ESanjeevani.InstituteMember.Entities;
using FluentMigrator;

namespace Infrastructure.Migrations.Fluent.ESanjeevani.InstituteMember
{
    public class AddInstituteMemberBulkEntityTable : Migration
    {
        public AddInstituteMemberBulkEntityTable()
        {
        }

        public override void Down()
        {
            var instituteMemberBulkEntity = new InstituteMemberBulkEntity();
            var tblName = instituteMemberBulkEntity.GetType().Name;
            Delete.Table(tblName);

        }

        public override void Up()
        {
            var instituteMemberBulkEntity = new InstituteMemberBulkEntity();
            var tblName = instituteMemberBulkEntity.GetType().Name;

            Create.Table(tblName)
              .WithColumn(nameof(instituteMemberBulkEntity.Id)).AsInt64().PrimaryKey().Identity()
              .WithColumn(nameof(instituteMemberBulkEntity.AssignedInstituteID)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.CreatedDate)).AsDateTime()
              .WithColumn(nameof(instituteMemberBulkEntity.DeletedDate)).AsDateTime()
              .WithColumn(nameof(instituteMemberBulkEntity.DOB)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.DRRegNo)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.Experience)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.HFAddress)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.HFCityId)).AsInt32()
              .WithColumn(nameof(instituteMemberBulkEntity.HFDistrictId)).AsInt32()
              .WithColumn(nameof(instituteMemberBulkEntity.HFName)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.HFPhone)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.HFPIN)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.HFShortName)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.HFStateId)).AsInt32()
              .WithColumn(nameof(instituteMemberBulkEntity.HFTypeId)).AsInt64()
              .WithColumn(nameof(instituteMemberBulkEntity.IsDelted)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.ModifiedDate)).AsDateTime()

              .WithColumn(nameof(instituteMemberBulkEntity.NIN)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.QualificationId)).AsInt32()
              .WithColumn(nameof(instituteMemberBulkEntity.SessionId)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.SpecialityId)).AsInt32()
              .WithColumn(nameof(instituteMemberBulkEntity.SubMenuNames)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.UserAddress)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.UserAvailableDay)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.UserAvailableFromTime)).AsInt32()
              .WithColumn(nameof(instituteMemberBulkEntity.UserAvailableToTime)).AsInt64()
              .WithColumn(nameof(instituteMemberBulkEntity.UserCityId)).AsInt32()
              .WithColumn(nameof(instituteMemberBulkEntity.UserDistrictId)).AsInt32()
              .WithColumn(nameof(instituteMemberBulkEntity.UserDistrictShortCode)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.UserEmail)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.UserFirstName)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.UserGenderId)).AsInt32()
              .WithColumn(nameof(instituteMemberBulkEntity.UserLastName)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.UserMobile)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.UserName)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.UserPin)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.UserPrefix)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.UserRole)).AsString()
              .WithColumn(nameof(instituteMemberBulkEntity.UserStateId)).AsInt32();

        }
    }
}


