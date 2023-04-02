using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using StaffAPI.Data;
using StaffAPI.Models;

namespace StaffAPI.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly StaffAPIDbContext dbContext;
        private readonly IMapper mapper;

        public StaffRepository(StaffAPIDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<StaffModel>> GetAllStaffs()
        {
            var staffs = await dbContext.Staffs.ToListAsync();

            return mapper.Map<List<StaffModel>>(staffs);
        }

        public async Task<StaffModel> GetSingleStaff(Guid Id)
        {
            var staff = await dbContext.Staffs.FindAsync(Id);

            return mapper.Map<StaffModel>(staff);
        }

        public async Task<Staffs> AddStaff(StaffModel staffModel)
        {
            var staff = new Staffs()
            {
                FirstName = staffModel.FirstName,
                LastName = staffModel.LastName,
                Email = staffModel.Email,
                Address = staffModel.Address
            };

            dbContext.Staffs.Add(staff);
            await dbContext.SaveChangesAsync();

            return staff;
        }

        public async Task<Staffs> UpdateStaff(Guid Id, StaffModel staffModel)
        {
            var staff = new Staffs()
            {
                Id = Id,
                FirstName = staffModel.FirstName,
                LastName = staffModel.LastName,
                Email = staffModel.Email,
                Address = staffModel.Address
            };

            dbContext.Staffs.Update(staff);
            await dbContext.SaveChangesAsync();

            return staff;
        }

        public async Task<Staffs> UpdateStaffPatch(Guid Id, JsonPatchDocument staffModel)
        {
            var staff = await dbContext.Staffs.FindAsync(Id);

            if(staff != null)
            {
                staffModel.ApplyTo(staff);
                await dbContext.SaveChangesAsync();
            }

            return staff;
        }

        public async Task DeleteStaff(Guid Id)
        {
            var staff = new Staffs()
            {
                Id = Id
            };

            dbContext.Remove(staff);
            await dbContext.SaveChangesAsync();
        }
    }
}
