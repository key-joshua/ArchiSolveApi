using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;

namespace Entities
{
    public class Cost : BaseEntity<int>
    {
        public int ReferenceId { get; set; }
        public ObjectType? ObjectType { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public byte PriceUnit { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public int? ListOrder { get; set; }

        //public virtual Project Project { get; set; }
        //public virtual ProjectExtension ProjectExtension { get; set; }
        //public virtual Content Content { get; set; }
        //public virtual Company Company { get; set; }
        //public virtual Group Group { get; set; }
        //public virtual Page Page { get; set; }
        //public virtual Profile Profile { get; set; }


    }


    public class ObjectPriceConfiguration : IEntityTypeConfiguration<Cost>
    {
        public void Configure(EntityTypeBuilder<Cost> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(500);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        }
    }

    public enum Currency
    {
        [Display(Name = "AUDollar", ResourceType = typeof(DataAnnotationsResources))]
        AUDollars = 1,

        [Display(Name = "Yuan", ResourceType = typeof(DataAnnotationsResources))]
        Yuan = 2,

        [Display(Name = "Euro", ResourceType = typeof(DataAnnotationsResources))]
        Euro = 3,
    }

}
