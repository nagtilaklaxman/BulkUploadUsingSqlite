using System;
using FluentMigrator.Runner.Initialization;

namespace Infrastructure
{
    public class UploaderLogDBConnectionStringReader : IConnectionStringReader, IUploaderLogDBConnectionStringModifier
    {
        private string _connectionString;

        public UploaderLogDBConnectionStringReader()
        {
        }

        public int Priority { get; } = 300;

        public string GetConnectionString(string connectionStringOrName)
        {
            return _connectionString;
        }
        public bool SetConnectionString(string folderPath, string sessionId)
        {
            _connectionString = $"{folderPath}/{sessionId}.db";
            return true;

        }
    }
}

