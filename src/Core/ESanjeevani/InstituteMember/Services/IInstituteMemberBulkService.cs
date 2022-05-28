using System;
using Core.ESanjeevani.InstituteMember.ViewModels;

namespace Core.ESanjeevani.InstituteMember.Services
{
    public interface IInstituteMemberBulkEntityService
    {
        Task<bool> Add(IList<InstituteMemberBulkEntityVM> data);
        Task<IList<InstituteMemberBulkEntityVM>> GetALL();
        Task<IList<InstituteMemberBulkEntityVM>> GetByPaging(int records, int pageNumber);
        Task<EditInstituteMemberBulkEntityVM> GetForEdit(int id);
        Task<EditInstituteMemberBulkEntityVM> Edit(EditInstituteMemberBulkEntityVM model);
        Task<bool> Delete(int id);
        Task<bool> Delete(IList<int> ids);
        Task<bool> DeleteAllInvalid();
        Task<bool> DeleteAllValid();
    }
}

