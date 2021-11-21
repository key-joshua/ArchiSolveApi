using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities
{
    public class ObjectDocument : IEntity
    {
        public long ObjectRef { get; set; }
        public virtual Object ObjectTRef { get; set; }

        public int DocumentRef { get; set; }
        public virtual Document DocumentTRef { get; set; }

        public bool IsActive { get; set; }
    }

    public class ObjectDocumentConfiguration : IEntityTypeConfiguration<ObjectDocument>
    {
        public void Configure(EntityTypeBuilder<ObjectDocument> builder)
        {
            builder.HasKey(oc => new { oc.ObjectRef, oc.DocumentRef });

            //builder.HasOne(oc => oc.ObjectTRef).WithMany(b => b.ObjectDocuments).HasForeignKey(bc => bc.ObjectRef);
            //builder.HasOne(bc => bc.DocumentTRef).WithMany(c => c.ObjectDocuments).HasForeignKey(bc => bc.DocumentRef);

        }
    }
}
