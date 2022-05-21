using System;
using Core.Events;
using MassTransit;

namespace API.Consumers
{
    public class MemeberBulkFileUpload : IConsumer<MemberBulkFileUploadedEvent>
    {
        readonly ILogger<MemeberBulkFileUpload> _logger;
        private readonly ILogFilePathLoder logFilePathLoder;

        public MemeberBulkFileUpload(ILogger<MemeberBulkFileUpload> logger, ILogFilePathLoder logFilePathLoder)
        {
            _logger = logger;
            this.logFilePathLoder = logFilePathLoder;
        }

        public async Task Consume(ConsumeContext<MemberBulkFileUploadedEvent> context)
        {
            await logFilePathLoder.SetLogFilePath($"{context.Message.SessionId}/logFile.log");
            _logger.LogInformation("Received File: {Text} and  SessionId : {SessionId} ", context.Message.FileName, context.Message.SessionId);
        }
    }
}

