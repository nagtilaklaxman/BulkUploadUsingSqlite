using System;
using System.Data;
using Infrastructure.Interfaces.Migrations;
using Microsoft.Data.Sqlite;

namespace Infrastructure.ESanjeevani.InstituteMember.Migrations
{
    public interface IInstituteMemberMigration : IBulkMigration
    {
    }

    public interface IInstituteMemberMigrator
    {
        public Task<bool> MigrateDatabaseAsync(string sessionId);
    }

    public interface IInstituteMemberConnectionFactory
    {
        public IDbConnection GetConnection(string sessionId);
    }

    public class InstituteMemberConnectionFactory : IInstituteMemberConnectionFactory
    {
        private readonly string _dbName = "uploadLog.db";
        private readonly string _folderPath = "Logs";
        public IDbConnection GetConnection(string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentNullException(nameof(sessionId));
            }
            var sqlConString = new SqliteConnectionStringBuilder
            {
                DataSource = $"{_folderPath}/{sessionId}/{_dbName}",
                Mode = SqliteOpenMode.ReadWriteCreate,
                ForeignKeys = true,
                Pooling = true

            }.ConnectionString;
            return new SqliteConnection(sqlConString);
        }
    }

    public interface IInstituteMemberSession
    {
        public string  SessionId { get; set; }
    }

    public class InstituteMemberSession : IInstituteMemberSession
    {
        public string SessionId { get; set; }
    }
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
            //var transaction = _dbConnection.BeginTransaction();
            try
            {
                foreach (var migration in _instituteMemberMigrations)
                {
                    var sql = migration.MigrationSql;
                    var cmd = _dbConnection.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                //transaction.Commit();
                Console.WriteLine("migration successful");
            }
            catch (Exception ex)
            {
                //transaction.Rollback();
                Console.WriteLine("Roll back db migration due to exception", ex);
            }
            finally
            {
                _dbConnection.Close();
            }
            return Task.FromResult(true);
        }
    }
}

