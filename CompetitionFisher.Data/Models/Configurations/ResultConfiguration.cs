using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionFisher.Data.Models.Configurations
{
    public class ResultConfiguration : EntityTypeConfiguration<Result>
    {
        public ResultConfiguration()
        {
            // Id
            HasKey(el => el.Id);
            Property(el => el.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // client must set the Id

            // TotalNumber
            Property(el => el.TotalWeight)
                .IsRequired();

            // TotalWeight
            Property(el => el.TotalNumber)
                .IsRequired();

            // ContestantId & Contestant
            // Configured on other side of the relationship

            // CompetitionId & Competition
            // Configured on other side of the relationship
        }
    }
}
