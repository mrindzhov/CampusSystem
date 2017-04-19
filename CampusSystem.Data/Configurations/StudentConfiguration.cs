namespace CampusSystem.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using CampusSystem.Models;

    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            this.HasMany(s => s.Guests)
              .WithOptional(g => g.StudentVisited)
              .HasForeignKey(g => g.StudentVisitedId)
              .WillCascadeOnDelete(false);

            this.HasRequired(s => s.University)
                .WithMany(u => u.Students)
                .HasForeignKey(s => s.UniversityId)
                .WillCascadeOnDelete(false);

           this.HasRequired(s => s.Room)
                .WithMany(r => r.Students).WillCascadeOnDelete(false);

        }
    }
}
