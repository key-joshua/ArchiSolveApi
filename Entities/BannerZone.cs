using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Resources;

namespace Entities
{
    public class BannerZone : IEntity
    {
        public int ZoneRef { get; set; }
        public virtual Zone Zone { get; set; }

        public int BannerRef { get; set; }
        public virtual Banner Banner { get; set; }

        public string Note { get; set; }

        public BannerZoneStatus Status { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public int? ListOrder { get; set; }

    }

    public class BannerZoneConfiguration : IEntityTypeConfiguration<BannerZone>
    {
        public void Configure(EntityTypeBuilder<BannerZone> builder)
        {
            builder.Property(p => p.Note).HasMaxLength(500);

            builder.HasKey(bc => new { bc.ZoneRef, bc.BannerRef });

            builder.HasOne(bc => bc.Zone).WithMany(b => b.BannerZones).HasForeignKey(bc => bc.ZoneRef);
            builder.HasOne(bc => bc.Banner).WithMany(c => c.BannerZones).HasForeignKey(bc => bc.BannerRef);
        }
    }

    public enum BannerZoneStatus
    {
        [Display(Name = "Active", ResourceType = typeof(DataAnnotationsResources))]
        Active = 1,

        [Display(Name = "InActive", ResourceType = typeof(DataAnnotationsResources))]
        InActive = 2,

        [Display(Name = "ActiveInDuration", ResourceType = typeof(DataAnnotationsResources))]
        ActiveInDuration = 3

    }

}
