using System.Data;
using Infrastructure.Interfaces;
using Microsoft.Data.Sqlite;
using Infrastructure.ESanjeevani.InstituteMember.Migrations;

namespace Infrastructure.contexts
{
    public class UploaderLogDBContext : IUploaderLogDBContext
    {
        private readonly IList<IInstituteMemberMigration> _instituteMemberMigrations;
        private IDbConnection _dbConnection;
        private string DbName = "uploadLog.db";
        public UploaderLogDBContext(IEnumerable<IInstituteMemberMigration> instituteMemberMigrations)
        {
            _instituteMemberMigrations = instituteMemberMigrations?.ToList();
        }

        public IDbConnection GetConnection => _dbConnection;

        public Task<bool> ApplyMigration()
        {
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

        public bool SetDbPath(string folderPath, string sessionId)
        {
            var directory = $"{folderPath}/{sessionId}";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string dbPath = $"{directory}/{DbName}";
            SetSqLiteConnection(dbPath);
            return true;

        }
        private void SetSqLiteConnection(string dbPath)
        {
            var sqlConString = new SqliteConnectionStringBuilder
            {
                DataSource = dbPath,
                Mode = SqliteOpenMode.ReadWriteCreate,
                ForeignKeys = true,
                Pooling = true

            }.ConnectionString;

            _dbConnection = new SqliteConnection(sqlConString);

        }

    }
}

