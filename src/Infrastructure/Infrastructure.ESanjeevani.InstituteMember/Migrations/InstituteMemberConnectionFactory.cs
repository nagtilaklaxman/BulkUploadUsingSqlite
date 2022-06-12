using System.Data;
using Microsoft.Data.Sqlite;

namespace Infrastructure.ESanjeevani.InstituteMember.Migrations;

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