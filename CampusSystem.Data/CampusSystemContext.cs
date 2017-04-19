namespace CampusSystem.Data
{
    using System.Data.Entity;
    using CampusSystem.Data.Configurations;
    using CampusSystem.Data.Seed;
    using CampusSystem.Models;

    public class CampusSystemContext : DbContext
    {

        public CampusSystemContext()
            : base("name=CampusSystemContext")
        {
            Database.SetInitializer(new CampusSystemInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CampusConfiguration());
            modelBuilder.Configurations.Add(new GuestConfiguration());
            modelBuilder.Configurations.Add(new RoomConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new UniversityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<Campus> Campuses { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }

    }
}