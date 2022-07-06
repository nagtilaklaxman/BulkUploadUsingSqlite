using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.ESanjeevani.InstituteMember.Queries;

public class GetInstituteMemberBulkEntityToEdit : IRequest<InstituteMemberBulkEntity>
{
    public int Id { get; set; }
}

public class GetInstituteMemberBulkEntityToEditHandler : IRequestHandler<GetInstituteMemberBulkEntityToEdit,
        InstituteMemberBulkEntity>
{
    private readonly IInstituteMemberBulkEntityRepository _repository;
    private readonly ILogger<GetInstituteMemberBulkEntityToEditHandler> _logger;

    public GetInstituteMemberBulkEntityToEditHandler(IInstituteMemberBulkEntityRepository repository, ILogger<GetInstituteMemberBulkEntityToEditHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<InstituteMemberBulkEntity> Handle(GetInstituteMemberBulkEntityToEdit request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.Id);
        return result;
    }
}