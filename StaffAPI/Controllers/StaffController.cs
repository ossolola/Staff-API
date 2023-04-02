using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StaffAPI.Models;
using StaffAPI.Repository;

namespace StaffAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaffs()
        {
            var staffs = await staffRepository.GetAllStaffs();

            return Ok(staffs);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetSingleStaff([FromRoute] Guid Id)
        {
            var staff = await staffRepository.GetSingleStaff(Id);

            if(staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff([FromBody] StaffModel staffModel)
        {
            var staff = await staffRepository.AddStaff(staffModel);

            return CreatedAtAction(nameof(AddStaff), staff);
        }

        [HttpPut]
        [Route("{Id:guid}")]
        public async Task<IActionResult> UpdateStaff([FromRoute] Guid Id, [FromBody] StaffModel staffModel)
        {
            var staff = await staffRepository.UpdateStaff(Id, staffModel);

            return CreatedAtAction(nameof(UpdateStaff), staff);
        }

        [HttpPatch]
        [Route("{Id:guid}")]
        public async Task<IActionResult> UpdateStaffPatch([FromRoute] Guid Id, [FromBody] JsonPatchDocument staffModel)
        {
            var staff = await staffRepository.UpdateStaffPatch(Id, staffModel);

            return CreatedAtAction(nameof(UpdateStaffPatch), staff);
        }

        [HttpDelete]
        [Route("{Id:guid}")]
        public async Task<IActionResult> DeleteStaff([FromRoute] Guid Id)
        {
             await staffRepository.DeleteStaff(Id);

            return Ok("Staff Deleted!");
        }
    }
}
