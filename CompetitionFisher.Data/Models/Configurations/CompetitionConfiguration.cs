using CompetitionFisher.Data.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CompetitionFisher.Data.Models.Configurations
{
    public class CompetitionConfiguration : EntityTypeConfiguration<Competition>
    {
        public CompetitionConfiguration()
        {
            // Id
            HasKey(el => el.Id);
            Property(el => el.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // client must set the Id

            // Auth0UserId
            Property(el => el.Auth0UserId)
                .IsRequired()
                .HasMaxLength(EntityTypeConfigurationConstants.SIZE_STRING_COLUMN_MEDIUM)
                .HasIndexAnnotation("IX_Auth0UserId", false);

            // ChampionshipId
            // Configured on other side of the relationship

            // Name
            Property(el => el.Name)
                .IsRequired()
                .HasMaxLength(EntityTypeConfigurationConstants.SIZE_STRING_COLUMN_MEDIUM);

            // Date
            Property(el => el.Date)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasPrecision(EntityTypeConfigurationConstants.PRECISION_DATETIME_NO_TIME);

            // Championship
            // Configured on other side of the relationship
        }
    }
}
