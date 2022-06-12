using System.Data;
using Microsoft.Data.Sqlite;

namespace Infrastructure.ESanjeevani.InstituteMember.Jobs;

public class InstituteMemberOptions
{
    private string _dbFolder = "logs";
    private string _dbName="uploadLog";
    private IDbConnection _connection;
    
    public IDbConnection Connection => _connection;
    public string DbFolder => _dbFolder;
    public string DbName => _dbName;
    
    public void UseSqlite(string dbFolder ,string dbName)
    {
        if (string.IsNullOrEmpty(dbFolder))
        {
            throw new ArgumentNullException(nameof(dbFolder));
        }
        if (string.IsNullOrEmpty(dbName))
        {
            throw new ArgumentNullException(nameof(dbName));
        }
        try
        {
            Path.GetDirectoryName(dbFolder);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        _dbFolder = dbFolder;
        _dbName = dbName;
        var dbPath = $"{dbFolder}/{dbName}.db";
        _connection = GetSqliteConnectionString(dbPath);
    }

    private IDbConnection GetSqliteConnectionString(string dbPath)
    {
        var sqlConString = new SqliteConnectionStringBuilder
        {
            DataSource = dbPath,
            Mode = SqliteOpenMode.ReadWriteCreate,
            ForeignKeys = true,
            Pooling = true
        }.ConnectionString;
        return new SqliteConnection(sqlConString);
    }

    public void SetSession(string sessionId)
    {
        var dbPath = $"{_dbFolder}/{sessionId}/{_dbName}.db"; 
        _connection = GetSqliteConnectionString(dbPath);
    }
}