using Domain.ESanjeevani.InstituteMember.Events;
using Domain.ESanjeevani.InstituteMember.Migrations;
using Infrastructure.ESanjeevani.InstituteMember.Migrations;
using MassTransit;

namespace API.Consumers
{
    public class CreateLogDB : IConsumer<FileUploadedEvent>
    {
        readonly ILogger<CreateLogDB> _logger;
        private readonly IInstituteMemberMigrator _migrator;

        public CreateLogDB(ILogger<CreateLogDB> logger, IInstituteMemberMigrator migrator)
        {
            _logger = logger;
            _migrator = migrator;
        }

        public async Task Consume(ConsumeContext<FileUploadedEvent> context)
        {
            await _migrator.MigrateDatabaseAsync(context.Message.SessionId);
            _logger.LogInformation("Create LogDB : Received File: {Text} and  SessionId : {SessionId} ", context.Message.FileName, context.Message.SessionId);
        }
    }
}

