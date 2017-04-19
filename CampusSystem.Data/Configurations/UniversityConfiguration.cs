using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusSystem.Models;

namespace CampusSystem.Data.Configurations
{

    public class UniversityConfiguration : EntityTypeConfiguration<University>
    {
        public UniversityConfiguration()
        {
            this.HasMany(u => u.Students)
                      .WithRequired(s => s.University)
                      .HasForeignKey(s => s.UniversityId)
                      .WillCascadeOnDelete(false);
        }
    }
}