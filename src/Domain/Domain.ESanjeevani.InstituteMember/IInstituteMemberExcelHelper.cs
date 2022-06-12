using Domain.ESanjeevani.InstituteMember.Entities;

namespace Domain.ESanjeevani.InstituteMember;

public interface IInstituteMemberExcelHelper // need to implement this interface
{
    Task<IReadOnlyList<InstituteMemberBulkEntity>> GetAsync(string filePath);
    Task<bool> WriteAsync(IReadOnlyList<InstituteMemberBulkEntity> data, string filePath);
}