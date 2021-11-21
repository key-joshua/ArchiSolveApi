using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities
{
    public class ObjectLocation : IEntity
    {
        public long ObjectRef { get; set; }
        public virtual Object ObjectTRef { get; set; }
        public int LocationRef { get; set; }
        public virtual Location LocationTRef { get; set; }
        public bool IsActive { get; set; }
        public int? ListOrder { get; set; }
    }


    public class ObjectLocationConfiguration : IEntityTypeConfiguration<ObjectLocation>
    {
        public void Configure(EntityTypeBuilder<ObjectLocation> builder)
        {
            builder.HasKey(oc => new { oc.LocationRef, oc.ObjectRef });

        }
    }
}
