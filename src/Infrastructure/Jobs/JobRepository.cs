using System.Data;
using Core.interfaces.Repository;
using Dapper;
using Microsoft.Extensions.Options;

namespace Infrastructure.Jobs;
public class JobRepository : IRepository<JobRecord>
{
    private readonly IDbConnection _connection;
    public JobRepository(IOptions<JobOptions> options)
    {
        _connection = options.Value.Connection;
    }
    public async Task<JobRecord> GetByIdAsync(int id)
    {
        var entity = new JobRecord();
        var sql = $@" SELECT * FROM Jobs WHERE {nameof(entity.Id)} = {id};";
        var result = await _connection.QueryFirstOrDefaultAsync<JobRecord>(sql);
        return result;
    }

    public async Task<IReadOnlyList<JobRecord>> GetAllAsync()
    {
       var entity = new JobRecord();
        var sql = " SELECT * FROM Jobs;";
        var results = await _connection.QueryAsync<JobRecord>(sql);
        return results?.ToList() ?? new List<JobRecord>();
    }

    public async Task<int> AddAsync(JobRecord entity)
    {
        var sql = $@" INSERT INTO Jobs (
                                        '{nameof(entity.Description)}'
                                        ,'{nameof(entity.IsCompleted)}'
                                        ,'{nameof(entity.JobData)}'
                                        ,'{nameof(entity.ModuleName)}'
                                        ,'{nameof(entity.SessionId)}'
                                    )
                             VALUES(
                                   '{entity.Description}'
                                   ,'{entity.IsCompleted}'
                                   ,'{entity.JobData}'
                                   ,'{entity.ModuleName}'
                                   ,'{entity.SessionId}'
                             );";
        return  await _connection.ExecuteAsync(sql);
    }

    public async Task<int> UpdateAsync(JobRecord entity)
    {
        var sql = $@" UPDATE Jobs  SET
                                        {nameof(entity.Description)} = '{entity.Description}'
                                        ,{nameof(entity.IsCompleted)} = '{entity.IsCompleted}'
                                        ,{nameof(entity.JobData)} = '{entity.JobData}'
                                        ,{nameof(entity.ModuleName)} = '{entity.ModuleName}'
                                        ,{nameof(entity.ModifiedDate)} = CURRENT_TIMESTAMP
                           WHERE {nameof(entity.Id)} = '{entity.Id}';
                           ";
        return  await _connection.ExecuteAsync(sql);
    }

    public async Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddRangeAsync(IList<JobRecord> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteRangeAsync(IList<int> ids)
    {
        throw new NotImplementedException();
    }
}