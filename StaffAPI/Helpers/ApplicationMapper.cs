using AutoMapper;
using StaffAPI.Data;
using StaffAPI.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace StaffAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Staffs, StaffModel>();
        }
    }
}
