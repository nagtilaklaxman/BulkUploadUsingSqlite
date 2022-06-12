using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Migrations;

namespace Infrastructure.ESanjeevani.InstituteMember.Migrations
{
    public class AddInstituteMemberBulkEntityTable : IInstituteMemberMigration
    {
        private readonly string _sql;
        public AddInstituteMemberBulkEntityTable()
        {
            InstituteMemberBulkEntity entity = new ();
            
            _sql = $@"
                    CREATE TABLE if not exists InstituteMemberBulkEntity (
                        {nameof(entity.Id)}                    INTEGER  NOT NULL
                                                               PRIMARY KEY AUTOINCREMENT,
                        {nameof(entity.AssignedInstituteID)}   TEXT,
                        {nameof(entity.CreatedDate)}           DATETIME NOT NULL
                                                               DEFAULT (CURRENT_TIMESTAMP),
                        {nameof(entity.DeletedDate)}           DATETIME,
                        {nameof(entity.DOB)}                   TEXT,
                        {nameof(entity.DRRegNo)}               TEXT,
                        {nameof(entity.Experience)}            TEXT,
                        {nameof(entity.HFAddress)}             TEXT,
                        {nameof(entity.HFCityId)}              INTEGER  NOT NULL
                                                               DEFAULT (0),
                        {nameof(entity.HFDistrictId)}          INTEGER  DEFAULT (0),
                        {nameof(entity.HFName)}                TEXT,
                        {nameof(entity.HFPhone)}               TEXT,
                        {nameof(entity.HFEmail)}               TEXT,
                        {nameof(entity.HFPIN)}                 TEXT,
                        {nameof(entity.HFShortName)}           TEXT     NOT NULL,
                        {nameof(entity.HFStateId)}             INTEGER  NOT NULL
                                                               DEFAULT (0),
                        {nameof(entity.HFTypeId)}              INTEGER  NOT NULL
                                                               DEFAULT (0),
                        {nameof(entity.IsDelted)}              TEXT     NOT NULL
                                                               DEFAULT (0),
                        {nameof(entity.ModifiedDate)}          DATETIME,
                        {nameof(entity.NIN)}                   TEXT,
                        {nameof(entity.QualificationId)}       INTEGER  NOT NULL
                                                               DEFAULT (0),
                        {nameof(entity.SessionId)}             TEXT     NOT NULL,
                        {nameof(entity.SpecialityId)}          INTEGER  NOT NULL
                                                               DEFAULT (0),
                        {nameof(entity.SubMenuNames)}          TEXT,
                        {nameof(entity.UserAddress)}           TEXT,
                        {nameof(entity.UserAvailableDay)}      TEXT,
                        {nameof(entity.UserAvailableFromTime)} INTEGER,
                        {nameof(entity.UserAvailableToTime)}   INTEGER,
                        {nameof(entity.UserCityId)}            INTEGER  NOT NULL
                                                               DEFAULT (0),
                        {nameof(entity.UserDistrictId)}        INTEGER  NOT NULL
                                                               DEFAULT (0),
                        {nameof(entity.UserDistrictShortCode)} TEXT,
                        {nameof(entity.UserEmail)}             TEXT,
                        {nameof(entity.UserFirstName)}         TEXT,
                        {nameof(entity.UserGenderId)}          INTEGER,
                        {nameof(entity.UserLastName)}          TEXT,
                        {nameof(entity.UserMobile)}            TEXT,
                        {nameof(entity.UserName)}              TEXT,
                        {nameof(entity.UserPin)}               TEXT,
                        {nameof(entity.UserPrefix)}            TEXT,
                        {nameof(entity.UserRole)}              TEXT,
                        {nameof(entity.UserStateId)}           INTEGER  NOT NULL
                                                               DEFAULT (0) 
                );";

        }

        public string MigrationSql => _sql;
    }
}

