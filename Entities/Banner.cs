using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;

namespace Entities
{
    public class Banner : BaseEntity<int>
    {
        public string Title { get; set; }
        public string ShortDescription{ get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public BannerType? Type { get; set; }
        public string SourceFileName { get; set; }
        public string Note { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }

        //public virtual Object Object { get; set; }
        public ICollection<BannerZone> BannerZones { get; set; }
        public ICollection<BannerTracking> BannerTrackings { get; set; }
    }

    public class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.Property(p => p.Note).HasMaxLength(500);
           // builder.Property(p => p.Culture).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(500);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.Url).HasMaxLength(3000);

           // builder.HasOne(a => a.Object).WithOne(b => b.Banner).HasForeignKey<Object>(b => b.BannerRef);
            builder.HasMany(a => a.BannerTrackings).WithOne(b => b.Banner).HasForeignKey(b => b.BannerRef);

        }
    }

    public enum BannerType
    {
        [Display(Name = "Image", ResourceType = typeof(DataAnnotationsResources))]
        Image = 1,

        [Display(Name = "Flash", ResourceType = typeof(DataAnnotationsResources))]
        Flash = 2,

        [Display(Name = "Link", ResourceType = typeof(DataAnnotationsResources))]
        Link = 3,

        [Display(Name = "HTML", ResourceType = typeof(DataAnnotationsResources))]
        HTML = 4
    }
}
