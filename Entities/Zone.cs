using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;
using System.Collections.Generic;

namespace Entities
{
    public class Zone : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Culture { get; set; }
        public bool IsActive { get; set; }
        public ICollection<BannerZone> BannerZones { get; set; }
    }

    public class ZoneConfiguration : IEntityTypeConfiguration<Zone>
    {
        public void Configure(EntityTypeBuilder<Zone> builder)
        {


            builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Culture).HasMaxLength(10);
        }
    }
}
