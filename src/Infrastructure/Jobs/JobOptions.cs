using System.Data;
using Microsoft.Data.Sqlite;

namespace Infrastructure.Jobs;

public class JobOptions
{
    private string _dbPath;
    private IDbConnection _connection;
    
    public TimeSpan Interval { get; set; }
    public IDbConnection Connection => _connection;
    
    public void UseSqlite(string dbPath)
    {
        if (string.IsNullOrEmpty(dbPath))
        {
            throw new ArgumentNullException(nameof(dbPath));
        }
        try
        {
            Path.GetDirectoryName(dbPath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        _dbPath = dbPath;
        var sqlConString = new SqliteConnectionStringBuilder
        {
            DataSource = $"{_dbPath}",
            Mode = SqliteOpenMode.ReadWriteCreate,
            ForeignKeys = true,
            Pooling = true
        }.ConnectionString;
        _connection = new SqliteConnection(sqlConString);
    }
}