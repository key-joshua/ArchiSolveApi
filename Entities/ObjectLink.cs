using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities
{
    public class ObjectLink : IEntity
    {
        public long ObjectRef { get; set; }
        public virtual Object ObjectTRef { get; set; }
        public int LinkRef { get; set; }
        public virtual Link LinkTRef { get; set; }

        public bool IsActive { get; set; }
    }

    public class ObjectLinkConfiguration : IEntityTypeConfiguration<ObjectLink>
    {
        public void Configure(EntityTypeBuilder<ObjectLink> builder)
        {
            builder.HasKey(oc => new { oc.LinkRef, oc.ObjectRef });

            //builder.HasOne(oc => oc.ObjectTRef).WithMany(b => b.ObjectLinks).HasForeignKey(bc => bc.ObjectRef);
            //builder.HasOne(bc => bc.LinkTRef).WithMany(c => c.ObjectLinks).HasForeignKey(bc => bc.LinkRef);
        }
    }
}
