namespace Infrastructure
{
    public interface IUploaderLogDBConnectionStringModifier
    {
        bool SetConnectionString(string folderPath, string sessionId);
    }
}