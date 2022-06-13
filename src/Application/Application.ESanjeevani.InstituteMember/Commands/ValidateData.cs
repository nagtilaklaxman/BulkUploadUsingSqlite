using Application.Job.Commands;
using Domain.Common.Entities;
using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Repository;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.ESanjeevani.InstituteMember.Commands;

public class ValidateData : IRequest<InstituteMemberCommandResponse>
{
    public ValidateData(JobRecord record)
    {
        JobRecord = record;
    }
    public JobRecord JobRecord { get; }
}
public class ValidateDataHandler : IRequestHandler<ValidateData,InstituteMemberCommandResponse>
{
    private readonly ILogger<ValidateDataHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<InstituteMemberBulkEntity> _validator;
    private IMediator _mediator;


    public ValidateDataHandler(ILogger<ValidateDataHandler> logger ,IUnitOfWork unitOfWork, IValidator<InstituteMemberBulkEntity> validator, IMediator mediator)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _mediator = mediator;
    }
    public async Task<InstituteMemberCommandResponse> Handle(ValidateData request, CancellationToken cancellationToken)
    {
        var job = request.JobRecord;
        var jobData = job.GetJobData<InstituteMemberJobData>();
        
        await _unitOfWork.SetSession(jobData.SessionId);
        var records = await _unitOfWork.BulkEntities.GetAllAsync();
        foreach (var record in records)
        {
            var result =  await _validator.ValidateAsync(record);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    record.Validations.Add(new BulkEntityValidation
                    {
                        BulkEntityId = record.Id,
                        PropertyName = error.PropertyName,
                        ErrorMessage = error.ErrorMessage
                    });
                }
            }
        }

        var validations = records.SelectMany(t => t.Validations)?.ToList();
        if (validations != null && validations.Any())
        {
            await _unitOfWork.BulkEntities.AddBulkEntityValidations(validations);
        }

        var validRecordsCount = records.Count(x => !x.Validations.Any() || x.Validations.All(t => t.IsDeleted)); 
        _logger.LogInformation($"Valid records / Total records : {validRecordsCount} / {records.Count}");
        
        jobData.Status = InstituteMemberTaskStatus.DataValidated;
        job.SetJobData(jobData);
        var updateJobData = new UpdateJob()
        {
            JobRecord = job
        };
        await _mediator.Send(updateJobData, cancellationToken);
        
        return new InstituteMemberCommandResponse
        {
            Status = "Validated", SessionId = jobData.SessionId,
            Message = $"Valid records {validRecordsCount} out of total records {records.Count}"
        };
        
    }
}