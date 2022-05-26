using System;
using Core.ESanjeevani.InstituteMember.Entities;
using FluentMigrator;

namespace Infrastructure.Migrations.Fluent.ESanjeevani.InstituteMember
{
    [Migration(20220526123000)]
    public class AddInstituteTable : Migration
    {
        public AddInstituteTable()
        {
        }

        public override void Down()
        {
            var institute = new Institute();
            var tblName = institute.GetType().Name + "s";
            Delete.Table(tblName);

        }

        public override void Up()
        {
            var institute = new Institute();
            var tblName = institute.GetType().Name + "s";

            Create.Table(tblName)
              .WithColumn(nameof(institute.Id)).AsInt64().PrimaryKey().Identity()
              .WithColumn(nameof(institute.AddressLine1)).AsString()
              .WithColumn(nameof(institute.AddressLine2)).AsString()
              .WithColumn(nameof(institute.CityId)).AsInt64()
              .WithColumn(nameof(institute.CountryId)).AsString()
              .WithColumn(nameof(institute.CreatedDate)).AsDateTime()
              .WithColumn(nameof(institute.DistrictId)).AsString()
              .WithColumn(nameof(institute.Email)).AsString()
              .WithColumn(nameof(institute.Fax)).AsString()
              .WithColumn(nameof(institute.ImagePath)).AsString()
              .WithColumn(nameof(institute.InstitutionTypeId)).AsString()
              .WithColumn(nameof(institute.IsActive)).AsString()
              .WithColumn(nameof(institute.Mobile)).AsString()
              .WithColumn(nameof(institute.Name)).AsString()
              .WithColumn(nameof(institute.PinCode)).AsString()
              .WithColumn(nameof(institute.SourceId)).AsString()
              .WithColumn(nameof(institute.StateId)).AsString()
              .WithColumn(nameof(institute.StatusIdpublic)).AsString()
              .WithColumn("LocalDbRecordId").AsInt64();
        }
    }
}


