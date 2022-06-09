using System;
using Infrastructure.Interfaces.Migrations;

namespace Infrastructure.ESanjeevani.InstituteMember.Migrations
{
    public class AddInstituteTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddInstituteTable()
        {
            _sql = @"
                    CREATE TABLE  if not exists Institutes (
                    InstituteId       INTEGER  NOT NULL  PRIMARY KEY AUTOINCREMENT,                                       
                    Id                INTEGER  NOT NULL  DEFAULT (0), 
                    AddressLine1      TEXT     ,
                    AddressLine2      TEXT     ,
                    CityId            INTEGER  NOT NULL DEFAULT (0),
                    CountryId         TEXT     NOT NULL DEFAULT (0),
                    CreatedDate       DATETIME ,
                    DistrictId        TEXT     NOT NULL DEFAULT (0),
                    Email             TEXT     ,
                    Fax               TEXT     ,
                    ImagePath         TEXT     ,
                    InstitutionTypeId TEXT     ,
                    IsActive          TEXT     ,
                    Mobile            TEXT     ,
                    Name              TEXT     ,
                    PinCode           TEXT     ,
                    SourceId          TEXT     ,
                    StateId           TEXT     DEFAULT (0),
                    StatusIdpublic    TEXT     ,
                    BulkEntityId      INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
}

