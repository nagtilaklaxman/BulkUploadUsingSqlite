using System.Data;
using Domain.ESanjeevani.InstituteMember.Migrations;

namespace Infrastructure.ESanjeevani.InstituteMember.Migrations;

public class InstituteMemberMigrator : IInstituteMemberMigrator
{
    private readonly IInstituteMemberConnectionFactory _connectionFactory;
    private readonly IReadOnlyList<IInstituteMemberMigration> _instituteMemberMigrations;
    private IDbConnection _dbConnection;
    public InstituteMemberMigrator(IInstituteMemberConnectionFactory connectionFactory, IEnumerable<IInstituteMemberMigration> instituteMemberMigrations)
    {
        _connectionFactory = connectionFactory;
        _instituteMemberMigrations = instituteMemberMigrations.ToList();
    }
    public  Task<bool> MigrateDatabaseAsync(string sessionId)
    {
        _dbConnection = _connectionFactory.GetConnection(sessionId);
        _dbConnection.Open();
        var transaction = _dbConnection.BeginTransaction();
        try
        {
            foreach (var migration in _instituteMemberMigrations)
            {
                var sql = migration.MigrationSql;
                var cmd = _dbConnection.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            Console.WriteLine("migration successful");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine("Roll back db migration due to exception", ex);
        }
        finally
        {
            _dbConnection.Close();
        }
        return Task.FromResult(true);
    }
}