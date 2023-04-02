using Microsoft.EntityFrameworkCore;

namespace StaffAPI.Data
{
    public class StaffAPIDbContext : DbContext
    {
        public StaffAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Staffs> Staffs { get; set; }
    }
}
