using System;

using Serilog.Core;
using Serilog.Events;

namespace API
{
    public class LogFilePathEnricher : ILogEventEnricher
    {
        private string _cachedLogFilePath;
        private LogEventProperty _cachedLogFilePathProperty;

        public const string LogFilePathPropertyName = "LogFilePath";



        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var logFilePath = "logs/bulkuploadApplication.log";

            LogEventProperty logFilePathProperty;

            if (logFilePath.Equals(_cachedLogFilePath))
            {
                // Path hasn't changed, so let's use the cached property
                logFilePathProperty = _cachedLogFilePathProperty;
            }
            else
            {
                // We've got a new path for the log. Let's create a new property
                // and cache it for future log events to use
                _cachedLogFilePath = logFilePath;

                _cachedLogFilePathProperty = logFilePathProperty =
                    propertyFactory.CreateProperty(LogFilePathPropertyName, logFilePath);
            }

            logEvent.AddPropertyIfAbsent(logFilePathProperty);
        }
    }

}

