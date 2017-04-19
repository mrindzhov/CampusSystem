namespace CampusSystem.Data.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;
    using CampusSystem.Models;

    public class RoomConfiguration : EntityTypeConfiguration<Room>
    {
        public RoomConfiguration()
        {
            //this.Property(c => c.Number)
            //           .IsRequired()
            //           .HasColumnAnnotation("Index",
            //               new IndexAnnotation(new[] { new IndexAttribute("Index") { IsUnique = true } }));

            //this.HasKey(r => new { r.CampusId, r.Number });

            this.HasRequired(r => r.Campus)
                .WithMany(c => c.Rooms)
                .WillCascadeOnDelete(false);
        }
    }
}
