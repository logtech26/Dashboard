using Dashboard.Model;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        
    }
}
