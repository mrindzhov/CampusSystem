namespace CampusSystem.Data
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using CampusSystem.Models;

    public class CampusSystemContext : DbContext
    {

        public CampusSystemContext()
            : base("name=CampusSystemContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CampusSystemContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>()
               .HasMany(u => u.Students)
               .WithRequired(s => s.University)
               .HasForeignKey(s => s.UniversityId)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Campus>()
                .Property(c => c.Number)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));

            //modelBuilder.Entity<Campus>()
            //    .HasMany(c => c.Rooms)
            //    .WithRequired(r => r.Campus)
            //    .HasForeignKey(r => new { r.CampusId, r.Number });


            modelBuilder.Entity<Room>()
                .Property(c => c.Number)
                .IsRequired()
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));

            //modelBuilder.Entity<Room>().HasKey(r => new { r.CampusId, r.Number });

            //modelBuilder.Entity<Room>()
            //    .HasRequired(r => r.Campus)
            //    .WithMany(c => c.Rooms)
            //    .HasForeignKey(r => new { r.CampusId, r.Number })
            //    .WillCascadeOnDelete(false);


            modelBuilder.Entity<Student>()
                .HasMany(s => s.Guests)
                .WithOptional(g => g.StudentVisited)
                .HasForeignKey(g => g.StudentVisitedId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
               .HasRequired(s => s.University)
               .WithMany(u => u.Students)
               .HasForeignKey(s => s.UniversityId)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasRequired(s => s.Room)
                .WithMany(r => r.Students).WillCascadeOnDelete(false);

            modelBuilder.Entity<Guest>()
                .HasOptional(g => g.StudentVisited)
                .WithMany()
                .HasForeignKey(g => g.StudentVisitedId)
                .WillCascadeOnDelete(false);

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