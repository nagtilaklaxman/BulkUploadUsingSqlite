using Infrastructure.Interfaces.Migrations;

namespace Infrastructure.Migrations.Scripts.ESanjeevani.InstituteMember
{
    public class AddInstituteMemberBulkEntityTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddInstituteMemberBulkEntityTable()
        {
            _sql = @"
                    CREATE TABLE if not exists InstituteMemberBulkEntity (
                    Id                    INTEGER  NOT NULL
                                                   PRIMARY KEY AUTOINCREMENT,
                    AssignedInstituteID   TEXT,
                    CreatedDate           DATETIME NOT NULL
                                                   DEFAULT (CURRENT_TIMESTAMP),
                    DeletedDate           DATETIME,
                    DOB                   TEXT,
                    DRRegNo               TEXT,
                    Experience            TEXT,
                    HFAddress             TEXT,
                    HFCityId              INTEGER  NOT NULL
                                                   DEFAULT (0),
                    HFDistrictId          INTEGER  DEFAULT (0),
                    HFName                TEXT,
                    HFPhone               TEXT,
                    HFPIN                 TEXT,
                    HFShortName           TEXT     NOT NULL,
                    HFStateId             INTEGER  NOT NULL
                                                   DEFAULT (0),
                    HFTypeId              INTEGER  NOT NULL
                                                   DEFAULT (0),
                    IsDelted              TEXT     NOT NULL
                                                   DEFAULT (0),
                    ModifiedDate          DATETIME,
                    NIN                   TEXT,
                    QualificationId       INTEGER  NOT NULL
                                                   DEFAULT (0),
                    SessionId             TEXT     NOT NULL,
                    SpecialityId          INTEGER  NOT NULL
                                                   DEFAULT (0),
                    SubMenuNames          TEXT,
                    UserAddress           TEXT,
                    UserAvailableDay      TEXT,
                    UserAvailableFromTime INTEGER,
                    UserAvailableToTime   INTEGER,
                    UserCityId            INTEGER  NOT NULL
                                                   DEFAULT (0),
                    UserDistrictId        INTEGER  NOT NULL
                                                   DEFAULT (0),
                    UserDistrictShortCode TEXT,
                    UserEmail             TEXT,
                    UserFirstName         TEXT,
                    UserGenderId          INTEGER,
                    UserLastName          TEXT,
                    UserMobile            TEXT,
                    UserName              TEXT,
                    UserPin               TEXT,
                    UserPrefix            TEXT,
                    UserRole              TEXT,
                    UserStateId           INTEGER  NOT NULL
                                                   DEFAULT (0) 
                );";

        }

        public string MigrationSql => _sql;
    }
}

