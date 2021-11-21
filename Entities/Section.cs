using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;
using System.Collections.Generic;

namespace Entities
{
    public class Section : BaseEntity<int>
    {
        public Section()
        {
            IsActive = true;
        }

        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Culture { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

    }
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Culture).IsRequired().HasMaxLength(10);

            //builder.HasOne(e => e.Section).WithMany(c => c.Groups); 
            //اگر این کلید خارجی رو نذاریم خودش به صورت shadowProperty کلید رو ایجاد می کنه
            builder.HasMany(e => e.Groups).WithOne(c => c.Section).HasForeignKey(e => e.SectionRef); ;
        }
    }

    

}
