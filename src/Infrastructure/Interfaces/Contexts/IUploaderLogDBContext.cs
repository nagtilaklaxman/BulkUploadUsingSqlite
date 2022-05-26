namespace Infrastructure.Interfaces
{
    public interface IUploaderLogDBContext : IConnectionContext
    {
        public bool SetDbPath(string folderPath, string sessionId);
        public Task<bool> ApplyMigration();
    }
}

