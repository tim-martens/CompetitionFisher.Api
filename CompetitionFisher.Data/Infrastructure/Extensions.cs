using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace CompetitionFisher.Data.Infrastructure
{
    public static class Extensions
    {
        /// <summary>
        /// Configures an index on the database column used to store the property
        /// </summary>
        /// <param name="property"></param>
        /// <param name="indexName">The name for the index. Use IX_ prefix for non-unique indexes. UX_ for unique indexes</param>
        /// <param name="isUnique">Create a unique index or not</param>
        /// <param name="columnOrder">Used for multi column index. HasIndexAnnotation must be applied to multiple properties</param>
        /// <returns></returns>
        public static PrimitivePropertyConfiguration HasIndexAnnotation(
            this PrimitivePropertyConfiguration property, string indexName, bool isUnique, int columnOrder = EntityTypeConfigurationConstants.POSITION_FIRST_INDEX_COLUMN)
        {
            var indexAttribute = new IndexAttribute(indexName, columnOrder) { IsUnique = isUnique };
            var indexAnnotation = new IndexAnnotation(indexAttribute);

            return property.HasColumnAnnotation(IndexAnnotation.AnnotationName, indexAnnotation);
        }
    }
}
