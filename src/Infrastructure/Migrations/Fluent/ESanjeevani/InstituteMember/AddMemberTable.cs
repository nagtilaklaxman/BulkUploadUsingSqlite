using Core.ESanjeevani.InstituteMember.Entities;
using FluentMigrator;

namespace Infrastructure.Migrations.Fluent.ESanjeevani.InstituteMember
{
    public class AddMemberTable : Migration
    {
        public AddMemberTable()
        {
        }

        public override void Down()
        {
            var member = new Member();
            var tblName = member.GetType().Name + "s";
            Delete.Table(tblName);

        }

        public override void Up()
        {
            var member = new Member();
            var tblName = member.GetType().Name + "s";

            Create.Table(tblName)
              .WithColumn(nameof(member.Id)).AsInt64().PrimaryKey().Identity()

              .WithColumn(nameof(member.AddressLine1)).AsString()
              .WithColumn(nameof(member.AddressLine2)).AsString()
              .WithColumn(nameof(member.AddressLine2)).AsString()
              .WithColumn(nameof(member.Age)).AsString()
              .WithColumn(nameof(member.AgeType)).AsString()

              .WithColumn(nameof(member.CityId)).AsInt64()
              .WithColumn(nameof(member.CountryId)).AsString()
              .WithColumn(nameof(member.CreatedDate)).AsDateTime()
              .WithColumn(nameof(member.CreationRolepublic)).AsString()

              .WithColumn(nameof(member.DistrictId)).AsString()
              .WithColumn(nameof(member.DOB)).AsString()

              .WithColumn(nameof(member.Email)).AsString()

              .WithColumn(nameof(member.Fax)).AsString()
              .WithColumn(nameof(member.FileFlag)).AsString()
              .WithColumn(nameof(member.FileName)).AsString()

              .WithColumn(nameof(member.GenderId)).AsString()

              .WithColumn(nameof(member.ImagePath)).AsString()
              .WithColumn(nameof(member.IsActive)).AsString()
              .WithColumn(nameof(member.IsAvailable)).AsString()
              .WithColumn(nameof(member.IsLoginOTPActive)).AsString()
              .WithColumn(nameof(member.IsMaster)).AsString()

              .WithColumn(nameof(member.LastName)).AsString()
              .WithColumn(nameof(member.LoginOTP)).AsString()

              .WithColumn(nameof(member.MiddleName)).AsString()
              .WithColumn(nameof(member.Mobile)).AsString()

              .WithColumn(nameof(member.Prefix)).AsString()
              .WithColumn(nameof(member.PinCode)).AsString()

              .WithColumn(nameof(member.QualificationId)).AsString()

              .WithColumn(nameof(member.RatingMasterId)).AsString()
              .WithColumn(nameof(member.RegistrationNumber)).AsString()

              .WithColumn(nameof(member.SignaturePath)).AsString()
              .WithColumn(nameof(member.SpecializationId)).AsString()
              .WithColumn(nameof(member.StatusId)).AsString()
              .WithColumn(nameof(member.SourceId)).AsString()
              .WithColumn(nameof(member.StateId)).AsString()

              .WithColumn("LocalDbRecordId").AsInt64();
        }
    }
}


