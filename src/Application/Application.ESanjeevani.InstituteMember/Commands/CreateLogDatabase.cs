using Domain.ESanjeevani.InstituteMember.Migrations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.ESanjeevani.InstituteMember.Commands;

public class CreateLogDatabase : IRequest<bool>
{
    public string SessionId { get; set; }
}
public class CreateLogDatabaseHandler : IRequestHandler<CreateLogDatabase, bool>
{
    private readonly ILogger<CreateLogDatabaseHandler> _logger;
    private readonly IInstituteMemberMigrator _migrator;

    public CreateLogDatabaseHandler(ILogger<CreateLogDatabaseHandler> logger, IInstituteMemberMigrator migrator)
    {
        _logger = logger;
        _migrator = migrator;
    }
    public async Task<bool> Handle(CreateLogDatabase request, CancellationToken cancellationToken)
    {
        await _migrator.MigrateDatabaseAsync(request.SessionId);
        _logger.LogInformation("Create LogDB : {SessionId} ", request.SessionId);
        return true;
    }
}