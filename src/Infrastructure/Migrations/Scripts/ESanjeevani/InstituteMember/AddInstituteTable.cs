using System;
using Infrastructure.Interfaces.Migrations;

namespace Infrastructure.Migrations.Scripts.ESanjeevani.InstituteMember
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
                    CityId            INTEGER  NOT NULL, DEFAULT (0),
                    CountryId         TEXT     NOT NULL, DEFAULT (0),
                    CreatedDate       DATETIME ,
                    DistrictId        TEXT     NOT NULL, DEFAULT (0),
                    Email             TEXT     ,
                    Fax               TEXT     ,
                    ImagePath         TEXT     ,
                    InstitutionTypeId TEXT     ,
                    IsActive          TEXT     ,
                    Mobile            TEXT     ,
                    Name              TEXT     ,
                    PinCode           TEXT     ,
                    SourceId          TEXT     ,
                    StateId           TEXT     , DEFAULT (0),
                    StatusIdpublic    TEXT     ,
                    BulkEntityId      INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
    public class AddAuditTrailTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddAuditTrailTable()
        {
            _sql = @"
                   CREATE TABLE if not exists AuditTrails (
                    AuditTrailId      INTEGER  NOT NULL  PRIMARY KEY AUTOINCREMENT,
                    Id                INTEGER  NOT NULL   DEFAULT (0),
                    AccessType        TEXT     ,
                    CreatedDate       DATETIME ,
                    EventId           TEXT     ,
                    IconPath          TEXT     ,
                    LocationIPAddress TEXT     ,
                    MemberId          TEXT     ,
                    Message           TEXT     ,
                    ModuleId          TEXT     ,
                    SourceId          TEXT     ,
                    UserTypeId        TEXT     ,
                    BulkEntityId      INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
    public class AddBulkEntityValidationTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddBulkEntityValidationTable()
        {
            _sql = @"
                   CREATE TABLE if not exists BulkEntityValidations (
                    Id           INTEGER  NOT NULL
                                          PRIMARY KEY AUTOINCREMENT,
                    BulkEntityId INTEGER  NOT NULL,
                    CreatedDate  DATETIME NOT NULL DEFAULT (CURRENT_TIMESTAMP),
                    DeletedDate  DATETIME ,
                    ErrorMessage TEXT     NOT NULL,
                    IsDeleted    INTEGER  NOT NULL DEFAULT (0),
                    PropertyName TEXT     NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
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
    public class AddMemberMenuTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddMemberMenuTable()
        {
            _sql = @"
                   CREATE TABLE if not exists MemberMenus (
                    MemberMenuId    INTEGER  NOT NULL  PRIMARY KEY AUTOINCREMENT,
                    Id              INTEGER  NOT NULL  DEFAULT (0),
                    IsActive        TEXT     ,
                    InstitutionId   INTEGER  NOT NULL  DEFAULT (0),
                    MemberId        INTEGER  NOT NULL  DEFAULT (0),
                    MenuMappingId   INTEGER  NOT NULL  DEFAULT (0),
                    RoleId          TEXT     ,
                    SourceId        TEXT     ,
                    CreatedDate     DATETIME NOT NULL
                                             DEFAULT (CURRENT_TIMESTAMP),
                    BulkEntityId    INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
    public class AddLoginTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddLoginTable()
        {
            _sql = @"
                    CREATE TABLE if not exists Logins (
                    LoginId         INTEGER  NOT NULL  PRIMARY KEY AUTOINCREMENT,
                    Id              INTEGER  NOT NULL  DEFAULT (0),
                    IsActive        TEXT     ,
                    Password        TEXT     NOT NULL,
                    ReferenceId     INTEGER  NOT NULL,
                    SourceId        TEXT     ,
                    UserName        TEXT     NOT NULL,
                    CreatedDate     DATETIME NOT NULL
                                             DEFAULT (CURRENT_TIMESTAMP),
                    BulkEntityId    INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
    public class AddInstitutionMemberTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddInstitutionMemberTable()
        {
            _sql = @"
                    CREATE TABLE if not exists InstitutionMembers (
                    InstitutionMemberId   INTEGER  NOT NULL  PRIMARY KEY AUTOINCREMENT,
                    Id                    INTEGER  NOT NULL  DEFAULT (0),
                    IsActive              TEXT     ,
                    InstitutionId         INTEGER  NOT NULL  DEFAULT (0),
                    MemberId              INTEGER  NOT NULL  DEFAULT (0),
                    SourceId              TEXT     ,
                    CreatedDate           DATETIME NOT NULL  DEFAULT (CURRENT_TIMESTAMP),
                    BulkEntityId          INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
    public class AddMemberSlotTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddMemberSlotTable()
        {
            _sql = @"
                    CREATE TABLE if not exists MemberSlots (
                    MemberSlotId    INTEGER  NOT NULL  PRIMARY KEY AUTOINCREMENT,
                    Id              INTEGER  NOT NULL  DEFAULT (0),
                    IsActive        TEXT     ,
                    Day             TEXT     ,
                    MemberId        INTEGER  NOT NULL  DEFAULT (0),
                    CreatedDate     DATETIME NOT NULL  DEFAULT (CURRENT_TIMESTAMP),
                    SlotFrom        TEXT     ,
                    SlotTo          TEXT     ,
                    SourceId        TEXT     ,
                    BulkEntityId    INTEGER  NOT NULL
                );";

        }

        public string MigrationSql => _sql;
    }
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

