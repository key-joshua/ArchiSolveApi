using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities
{
    public class Culture : BaseEntity<int>
    {
        public string Title { get; set; }
    }

    public class CultureConfiguration : IEntityTypeConfiguration<Culture>
    {
        public void Configure(EntityTypeBuilder<Culture> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(10);

        }
    }

}
