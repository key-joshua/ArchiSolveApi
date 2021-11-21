using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Page : BaseEntity<int>
    {
        public string Code { get; set; }
        public string UpperTitle { get; set; }
        public string Title { get; set; }
        public string BottomTitle { get; set; }
        public string Note { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
        public int? ListOrder { get; set; }
        public int? ParentId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public string Culture { get; set; }

        public virtual Page ParentPage { get; set; }
        public ICollection<Page> ChildPages { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual Location Location { get; set; }
        public virtual Cost Cost { get; set; }
        public virtual ICollection<Media> Medias { get; set; }

    }

    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.Property(p => p.UpperTitle).HasMaxLength(500);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(500);
            builder.Property(p => p.BottomTitle).HasMaxLength(500);
            builder.Property(p => p.Note).HasMaxLength(3000);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.SEOTitle).HasMaxLength(60);
            builder.Property(p => p.SEODescription).HasMaxLength(155);

            //builder.HasOne(a => a.Object).WithOne(b => b.Page).HasForeignKey<Object>(b => b.PageRef);
            //builder.HasOne(p => p.ParentPage).WithMany(c => c.ChildPages).HasForeignKey(p => p.ParentId);


            //builder.HasMany(a => a.Comments).WithOne(b => b.Page).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Documents).WithOne(b => b.Page).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Links).WithOne(b => b.Page).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Medias).WithOne(b => b.Page).HasForeignKey(b => b.ReferenceId);
            //builder.HasOne(a => a.Location).WithOne(b => b.Page).HasForeignKey<Location>(b => b.ReferenceId);
            //builder.HasOne(a => a.Cost).WithOne(b => b.Page).HasForeignKey<Cost>(b => b.ReferenceId);

        }
    }

    
}
