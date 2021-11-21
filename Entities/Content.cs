using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;
using System.Collections.Generic;
using System;

namespace Entities
{
    public class Content : BaseEntity<int>
    {
        public string Title { get; set; }
        public string UpperTitle { get; set; }
        public string BottomTitle { get; set; }
        public string ShortDescription { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public string Soustitre { get; set; }
        public string ShortTitle { get; set; }
        public string Source { get; set; }
        public string SourceURL { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
        public ContentType Type { get; set; }
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

    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.Property(p => p.Type).HasDefaultValue(ContentType.News);

            builder.Property(p => p.Title).IsRequired().HasMaxLength(500);
            builder.Property(p => p.UpperTitle).HasMaxLength(500);
            builder.Property(p => p.BottomTitle).HasMaxLength(100);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.Abstract).HasMaxLength(3000);
            builder.Property(p => p.Soustitre).HasMaxLength(3000);
            builder.Property(p => p.ShortTitle).HasMaxLength(500);
            builder.Property(p => p.Source).HasMaxLength(500);
            builder.Property(p => p.SourceURL).HasMaxLength(3000);

            builder.Property(p => p.SEOTitle).HasMaxLength(60);
            builder.Property(p => p.SEODescription).HasMaxLength(155);

            //builder.HasMany(a => a.Comments).WithOne(b => b.Content).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Documents).WithOne(b => b.Content).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Links).WithOne(b => b.Content).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Medias).WithOne(b => b.Content).HasForeignKey(b => b.ReferenceId);
            //builder.HasOne(a => a.Location).WithOne(b => b.Content).HasForeignKey<Location>(b => b.ReferenceId);
            //builder.HasOne(a => a.Cost).WithOne(b => b.Content).HasForeignKey<Cost>(b => b.ReferenceId);

        }
    }

    public enum ContentType
    {
        [Display(Name = "News", ResourceType = typeof(DataAnnotationsResources))]
        News = 1,

        [Display(Name = "Article", ResourceType = typeof(DataAnnotationsResources))]
        Article = 2,

        [Display(Name = "Gallery", ResourceType = typeof(DataAnnotationsResources))]
        Gallery = 3,

        [Display(Name = "Link", ResourceType = typeof(DataAnnotationsResources))]
        Link = 4,
    }

}
