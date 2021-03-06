using System.Data;
using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Repository;
using Dapper;
using Domain.Common.Entities;

namespace Infrastructure.ESanjeevani.InstituteMember.Repositories
{
    public class InstituteMemberBulkEntityRepository : IInstituteMemberBulkEntityRepository
    {
        private readonly IDbConnection _connection;

        public InstituteMemberBulkEntityRepository(IDbConnection connection)
        {
            _connection = connection;
            Console.WriteLine("options value : {0}",_connection.ConnectionString);
        }
        public async Task<int> AddAsync(InstituteMemberBulkEntity entity)
        {
            var sql = $@" INSERT INTO InstituteMemberBulkEntity (
                                        '{nameof(entity.AssignedInstituteID)}'
                                        ,'{nameof(entity.CreatedDate)}'
                                        ,'{nameof(entity.DeletedDate)}'
                                        ,'{nameof(entity.DOB)}'
                                        ,'{nameof(entity.DRRegNo)}'
                                        ,'{nameof(entity.Experience)}'
                                        ,'{nameof(entity.HFAddress)}'
                                        ,'{nameof(entity.HFCityId)}'
                                        ,'{nameof(entity.HFDistrictId)}'
                                        ,'{nameof(entity.HFEmail)}'
                                        ,'{nameof(entity.HFName)}'
                                        ,'{nameof(entity.HFPhone)}'
                                        ,'{nameof(entity.HFPIN)}'
                                        ,'{nameof(entity.HFShortName)}'
                                        ,'{nameof(entity.HFStateId)}'
                                        ,'{nameof(entity.HFTypeId)}'
                                        ,'{nameof(entity.IsDelted)}'
                                        ,'{nameof(entity.ModifiedDate)}'
                                        ,'{nameof(entity.NIN)}'
                                        ,'{nameof(entity.QualificationId)}'
                                        ,'{nameof(entity.SessionId)}'
                                        ,'{nameof(entity.SpecialityId)}'
                                        ,'{nameof(entity.SubMenuNames)}'
                                        ,'{nameof(entity.UserAddress)}'
                                        ,'{nameof(entity.UserAvailableDay)}'
                                        ,'{nameof(entity.UserAvailableFromTime)}'
                                        ,'{nameof(entity.UserAvailableToTime)}'
                                        ,'{nameof(entity.UserCityId)}'
                                        ,'{nameof(entity.UserDistrictId)}'
                                        ,'{nameof(entity.UserDistrictShortCode)}'
                                        ,'{nameof(entity.UserEmail)}'
                                        ,'{nameof(entity.UserFirstName)}'
                                        ,'{nameof(entity.UserGenderId)}'
                                        ,'{nameof(entity.UserLastName)}'
                                        ,'{nameof(entity.UserMobile)}'
                                        ,'{nameof(entity.UserPin)}'
                                        ,'{nameof(entity.UserPrefix)}'
                                        ,'{nameof(entity.UserRole)}'
                                        ,'{nameof(entity.UserStateId)}'
                                        ) values(
                                        '{entity.AssignedInstituteID}'
                                        ,'{entity.CreatedDate}'
                                        ,'{entity.DeletedDate}'
                                        ,'{entity.DOB}'
                                        ,'{entity.DRRegNo}'
                                        ,'{entity.Experience}'
                                        ,'{entity.HFAddress}'
                                        ,'{entity.HFCityId}'
                                        ,'{entity.HFDistrictId}'
                                        ,'{entity.HFEmail}'
                                        ,'{entity.HFName}'
                                        ,'{entity.HFPhone}'
                                        ,'{entity.HFPIN}'
                                        ,'{entity.HFShortName}'
                                        ,'{entity.HFStateId}'
                                        ,'{entity.HFTypeId}'
                                        ,'{entity.IsDelted}'
                                        ,'{entity.ModifiedDate}'
                                        ,'{entity.NIN}'
                                        ,'{entity.QualificationId}'
                                        ,'{entity.SessionId}'
                                        ,'{entity.SpecialityId}'
                                        ,'{entity.SubMenuNames}'
                                        ,'{entity.UserAddress}'
                                        ,'{entity.UserAvailableDay}'
                                        ,'{entity.UserAvailableFromTime}'
                                        ,'{entity.UserAvailableToTime}'
                                        ,'{entity.UserCityId}'
                                        ,'{entity.UserDistrictId}'
                                        ,'{entity.UserDistrictShortCode}'
                                        ,'{entity.UserEmail}'
                                        ,'{entity.UserFirstName}'
                                        ,'{entity.UserGenderId}'
                                        ,'{entity.UserLastName}'
                                        ,'{entity.UserMobile}'
                                        ,'{entity.UserPin}'
                                        ,'{entity.UserPrefix}'
                                        ,'{entity.UserRole}'
                                        ,'{entity.UserStateId}'
                                        )";

           return  await _connection.ExecuteAsync(sql);
        }

        public async Task<int> AddRangeAsync(IList<InstituteMemberBulkEntity> entities)
        {
            foreach (var entity in entities)
            {
                await AddAsync(entity);
            }

            return entities.Count();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = new InstituteMemberBulkEntity();
            var sql =
                $@" UPDATE InstituteMemberBulkEntity SET {nameof(entity.IsDelted)} = '1', {nameof(entity.DeletedDate)} =  CURRENT_TIMESTAMP
                        WHERE {nameof(entity.Id)} = {id};";
            
            return await _connection.ExecuteAsync(sql);
        }

        public async Task<int> DeleteRangeAsync(IList<int> ids)
        {
            var commaSeperatedIds = string.Join(",", ids);
            var entity = new InstituteMemberBulkEntity();
            var sql =
                $@" UPDATE InstituteMemberBulkEntity SET {nameof(entity.IsDelted)} = '1', {nameof(entity.DeletedDate)} =  CURRENT_TIMESTAMP
                        WHERE {nameof(entity.Id)} IN ({commaSeperatedIds});";
            
            return await _connection.ExecuteAsync(sql);
        }

        public async Task<PagedEntity<InstituteMemberBulkEntity>> GetPagedDataAsync(int page, int records)
        { 
            var entity = new InstituteMemberBulkEntity();
           var sql =$@" 
                            SELECT * FROM (
                                SELECT *
           FROM InstituteMemberBulkEntity limit {records} OFFSET {(page-1)*records} ) AS t 
           INNER JOIN BulkEntityValidations AS b ON t.Id = b.BulkEntityId AND b.IsDeleted = 0;
           ";
           
           var results = await _connection.QueryAsync<InstituteMemberBulkEntity, BulkEntityValidation, InstituteMemberBulkEntity>(sql, 
               (bulkEntity, validation) => {
                   bulkEntity.Validations.Add(validation);
                       return bulkEntity;
                   }, 
                   splitOn: "BulkEntityId" );
           var data = results?.ToList() ?? new List<InstituteMemberBulkEntity>();

           sql = "SELECT count(*) FROM  InstituteMemberBulkEntity;";
           var totalCount  = await _connection.ExecuteScalarAsync<int>(sql);

           return new PagedEntity<InstituteMemberBulkEntity>()
           {
               Page = page,
               Records = data.Count,
               Data = data,
               Total = totalCount
           };
        }

        public async Task<IReadOnlyList<InstituteMemberBulkEntity>> GetAllAsync()
        {
            var entity = new InstituteMemberBulkEntity();
            var sql = $@" SELECT 
                                         {nameof(entity.Id)}
                                        ,{nameof(entity.AssignedInstituteID)}
                                        ,{nameof(entity.DOB)}
                                        ,{nameof(entity.DRRegNo)}
                                        ,{nameof(entity.Experience)}
                                        ,{nameof(entity.HFAddress)}
                                        ,{nameof(entity.HFCityId)}
                                        ,{nameof(entity.HFDistrictId)}
                                        ,{nameof(entity.HFEmail)}
                                        ,{nameof(entity.HFName)}
                                        ,{nameof(entity.HFPhone)}
                                        ,{nameof(entity.HFPIN)}
                                        ,{nameof(entity.HFShortName)}
                                        ,{nameof(entity.HFStateId)}
                                        ,{nameof(entity.HFTypeId)}
                                        ,{nameof(entity.IsDelted)}
                                        ,{nameof(entity.NIN)}
                                        ,{nameof(entity.QualificationId)}
                                        ,{nameof(entity.SessionId)}
                                        ,{nameof(entity.SpecialityId)}
                                        ,{nameof(entity.SubMenuNames)}
                                        ,{nameof(entity.UserAddress)}
                                        ,{nameof(entity.UserAvailableDay)}
                                        ,{nameof(entity.UserAvailableFromTime)}
                                        ,{nameof(entity.UserAvailableToTime)}
                                        ,{nameof(entity.UserCityId)}
                                        ,{nameof(entity.UserDistrictId)}
                                        ,{nameof(entity.UserDistrictShortCode)}
                                        ,{nameof(entity.UserEmail)}
                                        ,{nameof(entity.UserFirstName)}
                                        ,{nameof(entity.UserGenderId)}
                                        ,{nameof(entity.UserLastName)}
                                        ,{nameof(entity.UserMobile)}
                                        ,{nameof(entity.UserPin)}
                                        ,{nameof(entity.UserPrefix)}
                                        ,{nameof(entity.UserRole)}
                                        ,{nameof(entity.UserStateId)}
           FROM InstituteMemberBulkEntity";
            var results = await _connection.QueryAsync<InstituteMemberBulkEntity>(sql);
            return results?.ToList() ?? new List<InstituteMemberBulkEntity>();
        }

        public async Task<InstituteMemberBulkEntity> GetByIdAsync(int id)
        {
            var entity = new InstituteMemberBulkEntity();
            var sql = $@" SELECT 
                                        {nameof(entity.Id)}
                                        ,{nameof(entity.AssignedInstituteID)}
                                        ,{nameof(entity.DOB)}
                                        ,{nameof(entity.DRRegNo)}
                                        ,{nameof(entity.Experience)}
                                        ,{nameof(entity.HFAddress)}
                                        ,{nameof(entity.HFCityId)}
                                        ,{nameof(entity.HFDistrictId)}
                                        ,{nameof(entity.HFEmail)}
                                        ,{nameof(entity.HFName)}
                                        ,{nameof(entity.HFPhone)}
                                        ,{nameof(entity.HFPIN)}
                                        ,{nameof(entity.HFShortName)}
                                        ,{nameof(entity.HFStateId)}
                                        ,{nameof(entity.HFTypeId)}
                                        ,{nameof(entity.IsDelted)}
                                        ,{nameof(entity.NIN)}
                                        ,{nameof(entity.QualificationId)}
                                        ,{nameof(entity.SessionId)}
                                        ,{nameof(entity.SpecialityId)}
                                        ,{nameof(entity.SubMenuNames)}
                                        ,{nameof(entity.UserAddress)}
                                        ,{nameof(entity.UserAvailableDay)}
                                        ,{nameof(entity.UserAvailableFromTime)}
                                        ,{nameof(entity.UserAvailableToTime)}
                                        ,{nameof(entity.UserCityId)}
                                        ,{nameof(entity.UserDistrictId)}
                                        ,{nameof(entity.UserDistrictShortCode)}
                                        ,{nameof(entity.UserEmail)}
                                        ,{nameof(entity.UserFirstName)}
                                        ,{nameof(entity.UserGenderId)}
                                        ,{nameof(entity.UserLastName)}
                                        ,{nameof(entity.UserMobile)}
                                        ,{nameof(entity.UserPin)}
                                        ,{nameof(entity.UserPrefix)}
                                        ,{nameof(entity.UserRole)}
                                        ,{nameof(entity.UserStateId)}
                            FROM InstituteMemberBulkEntity WHERE {nameof(entity.Id)} = {id};";
            var result = await _connection.QueryFirstOrDefaultAsync<InstituteMemberBulkEntity>(sql);
            return result;
        }

        public async Task<int> UpdateAsync(InstituteMemberBulkEntity entity)
        {
            var sql = $@" UPDATE InstituteMemberBulkEntity SET
                                        ,{nameof(entity.AssignedInstituteID)} =  '{entity.AssignedInstituteID}'
                                        ,{nameof(entity.DOB)} = '{entity.DOB}'
                                        ,'{nameof(entity.DRRegNo)}' = '{entity.DRRegNo}'
                                        ,'{nameof(entity.Experience)}' = '{entity.Experience}'
                                        ,'{nameof(entity.HFAddress)}' = '{entity.HFAddress}'
                                        ,'{nameof(entity.HFCityId)}' = '{entity.HFCityId}'
                                        ,'{nameof(entity.HFDistrictId)}' = '{entity.HFDistrictId}'
                                        ,'{nameof(entity.HFEmail)}' = '{entity.HFEmail}'
                                        ,'{nameof(entity.HFName)}' = '{entity.HFName}'
                                        ,'{nameof(entity.HFPhone)}' = '{entity.HFPhone}'
                                        ,'{nameof(entity.HFPIN)}' = '{entity.HFPIN}'
                                        ,'{nameof(entity.HFShortName)}' = '{entity.HFShortName}'
                                        ,'{nameof(entity.HFStateId)}' = '{entity.HFStateId}'
                                        ,'{nameof(entity.HFTypeId)}' = '{entity.HFTypeId}'
                                        ,'{nameof(entity.IsDelted)}' = '{entity.IsDelted}'
                                        ,'{nameof(entity.ModifiedDate)}' = CURRENT_TIMESTAMP
                                        ,'{nameof(entity.NIN)}' = '{entity.NIN}'
                                        ,'{nameof(entity.QualificationId)}' = '{entity.QualificationId}'
                                        ,'{nameof(entity.SessionId)}' = '{entity.SessionId}'
                                        ,'{nameof(entity.SpecialityId)}' = '{entity.SpecialityId}'
                                        ,'{nameof(entity.SubMenuNames)}' = '{entity.SubMenuNames}'
                                        ,'{nameof(entity.UserAddress)}' = '{entity.UserAddress}'
                                        ,'{nameof(entity.UserAvailableDay)}' = '{entity.UserAvailableDay}'
                                        ,'{nameof(entity.UserAvailableFromTime)}' = '{entity.UserAvailableFromTime}'
                                        ,'{nameof(entity.UserAvailableToTime)}' = '{entity.UserAvailableToTime}'
                                        ,'{nameof(entity.UserCityId)}' = '{entity.UserCityId}'
                                        ,'{nameof(entity.UserDistrictId)}' = '{entity.UserDistrictId}'
                                        ,'{nameof(entity.UserDistrictShortCode)}' = '{entity.UserDistrictShortCode}'
                                        ,'{nameof(entity.UserEmail)}' = '{entity.UserEmail}'
                                        ,'{nameof(entity.UserFirstName)}' = '{entity.UserFirstName}'
                                        ,'{nameof(entity.UserGenderId)}' = '{entity.UserGenderId}'
                                        ,'{nameof(entity.UserLastName)}' = '{entity.UserLastName}'
                                        ,'{nameof(entity.UserMobile)}' = '{entity.UserMobile}'
                                        ,'{nameof(entity.UserPin)}' = '{entity.UserPin}'
                                        ,'{nameof(entity.UserPrefix)}' = '{entity.UserPrefix}'
                                        ,'{nameof(entity.UserRole)}' = '{entity.UserRole}'
                                        ,'{nameof(entity.UserStateId)}' = '{entity.UserStateId}'
                                        WHERE {nameof(entity.Id)} = {entity.Id};";

            return await _connection.ExecuteAsync(sql);
        }

        public string Connectionstring {
            get
            {
                return _connection.ConnectionString;
            }
        }

        public async Task<int> AddBulkEntityValidations(IEnumerable<BulkEntityValidation> validations)
        {
            int retunvalue = 0;
            await DeleteBulkEntityValidations(validations);
            foreach (var entity in validations)
            {
                var sql = $@" INSERT INTO BulkEntityValidations (
                                     '{nameof(entity.BulkEntityId)}'
                                    ,'{nameof(entity.ErrorMessage)}'
                                    ,'{nameof(entity.PropertyName)}'
                                    )
                          VALUES (
                                  '{entity.BulkEntityId}'
                                  ,'{entity.ErrorMessage}'
                                ,'{entity.PropertyName}'
                          );";

                await _connection.ExecuteAsync(sql);
                retunvalue++;
            }

            return retunvalue;
        }

        public async Task<int> DeleteBulkEntityValidations(IEnumerable<BulkEntityValidation> validations)
        { 
            // need to fix the issue of validationId
            var commaSeperatedIds = string.Join(",",validations.Select(t => t.BulkEntityId.ToString()));
            var entity = new BulkEntityValidation();
            var sql = $@" UPDATE BulkEntityValidations SET {nameof(entity.IsDeleted)} = '1'
                         ,{nameof(entity.DeletedDate)} =  CURRENT_TIMESTAMP
                         WHERE {nameof(entity.BulkEntityId)} IN ({commaSeperatedIds});";

            return await _connection.ExecuteAsync(sql);
        }
    }
}

