using CompetitionFisher.Data.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CompetitionFisher.Data.Models.Configurations
{
    public class ChampionshipConfiguration : EntityTypeConfiguration<Championship>
    {
        public ChampionshipConfiguration()
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

            // Name
            Property(el => el.Name)
                .IsRequired()
                .HasMaxLength(EntityTypeConfigurationConstants.SIZE_STRING_COLUMN_MEDIUM);

            // Competitions
            HasMany(el => el.Competitions)
                .WithOptional(c => c.Championship) // championship is not mandatory for a competition
                .HasForeignKey(c => c.ChampionshipId);
        }

    }
}
