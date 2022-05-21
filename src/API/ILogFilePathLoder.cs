namespace API
{
    public interface ILogFilePathLoder
    {
        string GetLogFilePath();
        Task SetLogFilePath(string filePath);
    }
    public class LogFilePathLoader : ILogFilePathLoder
    {
        private string _logFilePath = "logs/bulkuploadApplication.log";

        public Task SetLogFilePath(string filePath)
        {
            this._logFilePath = filePath;
            return Task.CompletedTask;
        }

        public string GetLogFilePath()
        {
            return _logFilePath;
        }
    }
}