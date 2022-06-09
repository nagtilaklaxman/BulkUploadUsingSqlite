using System;
using Core.ESanjeevani.InstituteMember.Events;
using Core.interfaces.Repository;
using Infrastructure.ESanjeevani.InstituteMember.Jobs;
using Infrastructure.ESanjeevani.InstituteMember.Migrations;
using Infrastructure.Jobs;
using MassTransit;
using Newtonsoft.Json;

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

    public class CreateJob : IConsumer<FileUploadedEvent>
    {
        private readonly IRepository<JobRecord> _repository;
        private readonly ILogger<CreateJob> _logger;

        public CreateJob(IRepository<JobRecord> repository, ILogger<CreateJob> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<FileUploadedEvent> context)
        {
            var jobData = new InstituteMemberJobData()
            {
                FilePath = context.Message.Path,
                Status = InstituteMemberTaskStatus.FileReceived,
                Message = "File Received for Processing",
                SessionId = context.Message.SessionId
            };
            var record = new JobRecord()
            {
                ModuleName = "module.esanjeevani.institutemember",
                SessionId = context.Message.SessionId,
                JobData = JsonConvert.SerializeObject(jobData)
            };
            await _repository.AddAsync(record);
             _logger.LogInformation(" CreateJob : Received File : {Text} and  SessionId : {SessionId} ", context.Message.FileName, context.Message.SessionId);
        }
    }
}

