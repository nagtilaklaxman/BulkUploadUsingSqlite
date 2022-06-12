using System;
using Domain.ESanjeevani.InstituteMember.Entities;
using Domain.ESanjeevani.InstituteMember.Repository;
using Domain.ESanjeevani.InstituteMember.ViewModels;

namespace Domain.ESanjeevani.InstituteMember.Services
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
        private readonly IUnitOfWork _unitOfWork;

        public InstituteMemberBulkEntityService(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Add(IList<InstituteMemberBulkEntityVM> data)
        {
            foreach (var record in data)
            {
                // Mapper code
                var entity = new InstituteMemberBulkEntity();
                await _unitOfWork.BulkEntities.AddAsync(entity);
            }

            return true;
        }

        public async Task<IList<InstituteMemberBulkEntityVM>> GetALL()
        {
            var entities = await _unitOfWork.BulkEntities.GetAllAsync();
            //Mapper code
            return new List<InstituteMemberBulkEntityVM>();
        }

        public async Task<IList<InstituteMemberBulkEntityVM>> GetByPaging(int records, int pageNumber)
        {
            var entities = await _unitOfWork.BulkEntities.GetAllAsync();
            //Mapper code
            return new List<InstituteMemberBulkEntityVM>();
        }

        public async Task<EditInstituteMemberBulkEntityVM> GetForEdit(int id)
        {
            var entities = await _unitOfWork.BulkEntities.GetByIdAsync(id);
            //Mapper code
            return new EditInstituteMemberBulkEntityVM();
        }

        public async Task<EditInstituteMemberBulkEntityVM> Edit(EditInstituteMemberBulkEntityVM model)
        {
            //Mapper code
            var entities = await _unitOfWork.BulkEntities.UpdateAsync(new InstituteMemberBulkEntity()); 
            return  model;
        }

        public async Task<bool> Delete(int id)
        {
            var entities = await _unitOfWork.BulkEntities.DeleteAsync(id);
            return true;
        }

        public async Task<bool> Delete(IList<int> ids)
        {
            var entities = await _unitOfWork.BulkEntities.DeleteRangeAsync(ids);
            return true;
        }

        public async Task<bool> DeleteAllInvalid()
        {
            //Get Invalid  ids;
            var ids = new List<int>();
            var entities = await _unitOfWork.BulkEntities.DeleteRangeAsync(ids);
            return true;
        }

        public async Task<bool> DeleteAllValid()
        {
            //Get valid  ids;
            var ids = new List<int>();
            var entities = await _unitOfWork.BulkEntities.DeleteRangeAsync(ids);
            return true;
        }
    }
}

