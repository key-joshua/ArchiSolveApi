using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities
{
    public class ObjectMedia : IEntity
    {
        public long? ObjectRef { get; set; }
        public virtual Object ObjectTRef { get; set; }
        public int MediaRef { get; set; }
        public virtual Media MediaTRef { get; set; }
        public MediaType Type { get; set; }
        public string Title { get; set; }
        public bool IsPublished { get; set; }

        public DateTime? CreationDateTime { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
    }

    public class ObjectMediaConfiguration : IEntityTypeConfiguration<ObjectMedia>
    {
        public void Configure(EntityTypeBuilder<ObjectMedia> builder)
        {
            builder.HasKey(oc => new { oc.MediaRef, oc.ObjectRef });


            builder.Property(p => p.Title).HasMaxLength(500);

            //builder.HasOne(oc => oc.ObjectTRef).WithMany(b => b.ObjectMedias).HasForeignKey(bc => bc.ObjectRef);
            //builder.HasOne(bc => bc.MediaTRef).WithMany(c => c.ObjectMedias).HasForeignKey(bc => bc.MediaRef);

          
        }
    }
}
