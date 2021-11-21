using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;

namespace Entities
{
    public class Property : BaseEntity<int>
    {
        public string Title { get; set; }
        public PropertyType Type { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public int? ListOrder { get; set; }
        public string Culture { get; set; }

        public Location CityLocation { get; set; }
        public Location CountryLocation { get; set; }
        public Location StateLocation { get; set; }
        public Location SuburbLocation { get; set; }
    }

    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {


            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Value).IsRequired().HasMaxLength(50);


            builder.HasOne(a => a.CityLocation).WithOne(b => b.CityProperty).HasForeignKey<Location>(b => b.CityRef);
            builder.HasOne(a => a.CountryLocation).WithOne(b => b.CountryProperty).HasForeignKey<Location>(b => b.CountryRef);
            builder.HasOne(a => a.StateLocation).WithOne(b => b.StateProperty).HasForeignKey<Location>(b => b.StateRef);
            builder.HasOne(a => a.SuburbLocation).WithOne(b => b.SuburbProperty).HasForeignKey<Location>(b => b.SuburbRef);

        }
    }

    public enum PropertyType
    {
        [Display(Name = "Country", ResourceType = typeof(DataAnnotationsResources))]
        Country = 1,

        [Display(Name = "State", ResourceType = typeof(DataAnnotationsResources))]
        State = 2,

        [Display(Name = "City", ResourceType = typeof(DataAnnotationsResources))]
        City = 3,

        [Display(Name = "Suburbt", ResourceType = typeof(DataAnnotationsResources))]
        Suburbt = 4,

        [Display(Name = "PriceUnit", ResourceType = typeof(DataAnnotationsResources))]
        PriceUnit = 5,
    }
}
