using CompetitionFisher.Data.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CompetitionFisher.Data.Models.Configurations
{
    public class ContestantConfiguration : EntityTypeConfiguration<Contestant>
    {
        public ContestantConfiguration()
        {
            // Id
            HasKey(el => el.Id);
            Property(el => el.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // client must set the Id

            // Auth0UserId
            Property(el => el.Auth0UserId)
                .HasMaxLength(EntityTypeConfigurationConstants.SIZE_STRING_COLUMN_MEDIUM); // Not mandatory: not every contestant is an app user

            // FirstName
            Property(el => el.FirstName)
                .HasMaxLength(EntityTypeConfigurationConstants.SIZE_STRING_COLUMN_MEDIUM); // Not mandatory: Only used in frontend if no Auth0UserId

            // LastName
            Property(el => el.LastName)
                .HasMaxLength(EntityTypeConfigurationConstants.SIZE_STRING_COLUMN_MEDIUM); // Not mandatory: Only used in frontend if no Auth0UserId

            // Competitions
            // Configured on other side of the relationship

            // Results
            HasMany(el => el.Results)
                .WithRequired(r => r.Contestant)
                .HasForeignKey(r => r.ContestantId);
        }
    }
}
