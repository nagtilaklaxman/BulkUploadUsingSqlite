using Domain.Common.Entities;
using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.ESanjeevani.InstituteMember.Queries;

public class GetPagedInstituteMemberBulkEntity : IRequest<PagedEntity<InstituteMemberBulkEntity>>
{
    public int Page { get; set; }
    public int Records { get; set; }
}

public class GetPagedInstituteMembersHandler : IRequestHandler<GetPagedInstituteMemberBulkEntity,PagedEntity<InstituteMemberBulkEntity>>
{
    private readonly IInstituteMemberBulkEntityRepository _repository;
    private readonly ILogger<GetPagedInstituteMembersHandler> _logger;

    public GetPagedInstituteMembersHandler(IInstituteMemberBulkEntityRepository repository, ILogger<GetPagedInstituteMembersHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<PagedEntity<InstituteMemberBulkEntity>> Handle(GetPagedInstituteMemberBulkEntity request, CancellationToken cancellationToken)
    {
        var records = await _repository.GetPagedDataAsync(request.Page,request.Records);
        return records;
    }
}