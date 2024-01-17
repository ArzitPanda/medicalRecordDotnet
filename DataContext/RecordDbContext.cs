using Microsoft.EntityFrameworkCore;
using RecordMedical.Model;

namespace RecordMedical.DataContext
{
    public class RecordDbContext :DbContext
    {
        public RecordDbContext(DbContextOptions<RecordDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<MedicalReport> MedicalReport { get; set; }
        public DbSet<PasswordManager> PasswordManagers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>()
             .Property(e => e.Relation)
             .HasConversion<int>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
