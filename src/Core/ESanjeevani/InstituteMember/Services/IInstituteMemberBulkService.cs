using System;
using Core.ESanjeevani.InstituteMember.Entities;
using Core.ESanjeevani.InstituteMember.Repository;
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

    public class InstituteMemberBulkEntityService : IInstituteMemberBulkEntityService
    {
        private readonly IInstituteMemberBulkEntityRepository _repository;

        public InstituteMemberBulkEntityService(IInstituteMemberBulkEntityRepository repository )
        {
            _repository = repository;
        }
        public async Task<bool> Add(IList<InstituteMemberBulkEntityVM> data)
        {
            foreach (var record in data)
            {
                // Mapper code
                var entity = new InstituteMemberBulkEntity();
                await _repository.AddAsync(entity);
            }

            return true;
        }

        public async Task<IList<InstituteMemberBulkEntityVM>> GetALL()
        {
            var entities = await _repository.GetAllAsync();
            //Mapper code
            return new List<InstituteMemberBulkEntityVM>();
        }

        public async Task<IList<InstituteMemberBulkEntityVM>> GetByPaging(int records, int pageNumber)
        {
            var entities = await _repository.GetAllAsync();
            //Mapper code
            return new List<InstituteMemberBulkEntityVM>();
        }

        public async Task<EditInstituteMemberBulkEntityVM> GetForEdit(int id)
        {
            var entities = await _repository.GetByIdAsync(id);
            //Mapper code
            return new EditInstituteMemberBulkEntityVM();
        }

        public async Task<EditInstituteMemberBulkEntityVM> Edit(EditInstituteMemberBulkEntityVM model)
        {
            //Mapper code
            var entities = await _repository.UpdateAsync(new InstituteMemberBulkEntity()); 
            return  model;
        }

        public async Task<bool> Delete(int id)
        {
            var entities = await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> Delete(IList<int> ids)
        {
            var entities = await _repository.DeleteRangeAsync(ids);
            return true;
        }

        public async Task<bool> DeleteAllInvalid()
        {
            //Get Invalid  ids;
            var ids = new List<int>();
            var entities = await _repository.DeleteRangeAsync(ids);
            return true;
        }

        public async Task<bool> DeleteAllValid()
        {
            //Get valid  ids;
            var ids = new List<int>();
            var entities = await _repository.DeleteRangeAsync(ids);
            return true;
        }
    }
}

