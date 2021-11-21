using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class ProjectExtension : BaseEntity<int>
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Slagon { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public int? ListOrder { get; set; }
        public int? ProjectRef { get; set; }
        public virtual Project Project { get; set; }
       
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public string Culture { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual Location Location { get; set; }
        public virtual Cost Cost { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
    }

    public class ProjectExtensionConfiguration : IEntityTypeConfiguration<ProjectExtension>
    {
        public void Configure(EntityTypeBuilder<ProjectExtension> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(500);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.Slagon).HasMaxLength(1000);
            builder.Property(p => p.URL).HasMaxLength(3000);


            //builder.HasMany(a => a.Comments).WithOne(b => b.ProjectExtension).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Documents).WithOne(b => b.ProjectExtension).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Links).WithOne(b => b.ProjectExtension).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Medias).WithOne(b => b.ProjectExtension).HasForeignKey(b => b.ReferenceId);
            //builder.HasOne(a => a.Location).WithOne(b => b.ProjectExtension).HasForeignKey<Location>(b => b.ReferenceId);
            //builder.HasOne(a => a.Cost).WithOne(b => b.ProjectExtension).HasForeignKey<Cost>(b => b.ReferenceId);
            //builder.HasOne(a => a.Object).WithOne(b => b.ProjectExtension).HasForeignKey<Object>(b => b.ProjectExtensionRef);
        }
    }
}
