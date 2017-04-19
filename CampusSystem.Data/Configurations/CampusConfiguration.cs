using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
namespace CampusSystem.Data.Configurations
{
    using CampusSystem.Models;

    public class CampusConfiguration : EntityTypeConfiguration<Campus>
    {
        public CampusConfiguration()
        {

            this.Property(c => c.Number)
              .IsRequired()
              .HasColumnAnnotation("Index",
                  new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));

            //modelBuilder.Entity<Campus>()
            //    .HasMany(c => c.Rooms)
            //    .WithRequired(r => r.Campus)
            //    .HasForeignKey(r => new { r.CampusId, r.Number });

        }
    }
}
