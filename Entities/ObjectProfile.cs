using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities
{
    public class ObjectProfile : IEntity
    {
        public long ObjectRef { get; set; }
        public virtual Object ObjectTRef { get; set; }
        public int ProfileRef { get; set; }
        public virtual Profile ProfileTRef { get; set; }
        public bool IsActive { get; set; }
        public int? ListOrder { get; set; }
    }


    public class ObjectProfileConfiguration : IEntityTypeConfiguration<ObjectProfile>
    {
        public void Configure(EntityTypeBuilder<ObjectProfile> builder)
        {

            builder.HasKey(oc => new { oc.ProfileRef, oc.ObjectRef });

            //builder.HasOne(oc => oc.Object).WithMany(b => b.ObjectProfiles).HasForeignKey(bc => bc.ObjectRef);
            //builder.HasOne(bc => bc.Profile).WithMany(c => c.ObjectProfiles).HasForeignKey(bc => bc.ProfileRef);

        }
    }
}
