using System;
using Core.ESanjeevani.InstituteMember.Events;
using FluentMigrator.Runner;
using MassTransit;

namespace API.Consumers
{
    public class MemeberBulkFileUpload : IConsumer<FileUploadedEvent>
    {
        readonly ILogger<MemeberBulkFileUpload> _logger;
        private readonly ILogFilePathLoder logFilePathLoder;

        public MemeberBulkFileUpload(ILogger<MemeberBulkFileUpload> logger, ILogFilePathLoder logFilePathLoder)
        {
            _logger = logger;
            this.logFilePathLoder = logFilePathLoder;
        }

        public async Task Consume(ConsumeContext<FileUploadedEvent> context)
        {
            await logFilePathLoder.SetLogFilePath($"{context.Message.SessionId}/logFile.log");
            _logger.LogInformation("Received File: {Text} and  SessionId : {SessionId} ", context.Message.FileName, context.Message.SessionId);
        }
    }
}

