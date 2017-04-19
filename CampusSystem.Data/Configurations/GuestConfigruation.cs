namespace CampusSystem.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;
    using CampusSystem.Models;

    public class GuestConfiguration : EntityTypeConfiguration<Guest>
    {
        public GuestConfiguration()
        {
            this.HasOptional(g => g.StudentVisited)
                            .WithMany()
                            .HasForeignKey(g => g.StudentVisitedId)
                            .WillCascadeOnDelete(false);

        }
    }
}
