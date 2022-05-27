using Infrastructure.Interfaces.Migrations;

namespace Infrastructure.Migrations.Scripts.ESanjeevani.InstituteMember
{
    public class AddMemberTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddMemberTable()
        {
            _sql = @"
                    CREATE TABLE if not exists Members (
                    MemberId           INTEGER  NOT NULL  PRIMARY KEY AUTOINCREMENT,
                    Id                 INTEGER  NOT NULL  DEFAULT (0),
                    AddressLine1       TEXT     ,
                    AddressLine2       TEXT     ,
                    Age                TEXT     ,
                    AgeType            TEXT     ,
                    CityId             INTEGER  NOT NULL  DEFAULT (0),
                    CountryId          TEXT     NOT NULL  DEFAULT (0),
                    CreatedDate        DATETIME NOT NULL  DEFAULT (CURRENT_TIMESTAMP),
                    CreationRolepublic TEXT     ,
                    DistrictId         TEXT     NOT NULL  DEFAULT (0),
                    DOB                TEXT     ,
                    Email              TEXT     ,
                    Fax                TEXT     ,
                    FileFlag           TEXT     ,
                    FileName           TEXT     ,
                    GenderId           INTEGER  NOT NULL  DEFAULT (0),
                    ImagePath          TEXT     ,
                    IsActive           TEXT     ,
                    IsAvailable        TEXT     ,
                    IsLoginOTPActive   TEXT     ,
                    IsMaster           INTEGER  NOT NULL  DEFAULT (0),
                    LastName           TEXT     ,
                    LoginOTP           TEXT     ,
                    MiddleName         TEXT     ,
                    Mobile             TEXT     ,
                    Prefix             TEXT     ,
                    PinCode            TEXT     ,
                    QualificationId    INTEGER  NOT NULL  DEFAULT (0),
                    RatingMasterId     TEXT     ,
                    RegistrationNumber TEXT     ,
                    SignaturePath      TEXT     ,
                    SpecializationId   INTEGER  NOT NULL  DEFAULT (0),
                    StatusId           TEXT     ,
                    SourceId           TEXT     ,
                    StateId            INTEGER  NOT NULL  DEFAULT (0),
                    BulkEntityId       INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
}

