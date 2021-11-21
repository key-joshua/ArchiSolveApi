using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;

namespace Entities
{
    public class BannerTracking : BaseEntity<int>
    {
        public int Count { get; set; }
        public BannerTrackingType Type { get; set; }
        public string Note { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public int BannerRef { get; set; }
        public virtual Banner Banner { get; set; }
    }

    public class BannerTrackingConfiguration : IEntityTypeConfiguration<BannerTracking>
    {
        public void Configure(EntityTypeBuilder<BannerTracking> builder)
        {
            builder.Property(p => p.Note).HasMaxLength(500);
        }
    }


    public enum BannerTrackingType
    {
        [Display(Name = "Click", ResourceType = typeof(DataAnnotationsResources))]
        Click = 1,

        [Display(Name = "View", ResourceType = typeof(DataAnnotationsResources))]
        View = 2,

        [Display(Name = "Redirect", ResourceType = typeof(DataAnnotationsResources))]
        Link = 3

    }

}
