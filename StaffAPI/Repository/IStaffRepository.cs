using Microsoft.AspNetCore.JsonPatch;
using StaffAPI.Data;
using StaffAPI.Models;

namespace StaffAPI.Repository
{
    public interface IStaffRepository 
    {
        Task<List<StaffModel>> GetAllStaffs();
        Task<StaffModel> GetSingleStaff(Guid Id);
        Task<Staffs> AddStaff(StaffModel staffModel);
        Task<Staffs> UpdateStaff(Guid Id, StaffModel staffModel);
        Task<Staffs> UpdateStaffPatch(Guid Id, JsonPatchDocument staffModel);
        Task DeleteStaff(Guid Id);
    }
}
