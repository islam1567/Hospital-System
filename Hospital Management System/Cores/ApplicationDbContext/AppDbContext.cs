using Hospital_Management_System.Cores.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Cores.ApplicationDbContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Nurses> Nurses { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Doctor_patient> doctor_Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor_patient>().
            HasKey(e => new { e.Patient_Id, e.Doctor_Id }
            );
        }
    }
}
