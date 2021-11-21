using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;
using System.Collections.Generic;

namespace Entities
{
    public class Company : BaseEntity<int>
    {
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Slagon { get; set; }
        public CompanyType? CompanyType { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Cellphone { get; set; }
        public string Address { get; set; }
        public DateTime? StablishDateTime { get; set; }
        public DateTime? StartCooperationDateTime { get; set; }
        public DateTime? EndCooperationDateTime { get; set; }
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

    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(p => p.CompanyName).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Title).HasMaxLength(200);
            builder.Property(p => p.Slagon).HasMaxLength(1000);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.Website).HasMaxLength(3000);
            builder.Property(p => p.Email).HasMaxLength(300);
            builder.Property(p => p.PrimaryPhoneNumber).HasMaxLength(50);
            builder.Property(p => p.SecondaryPhoneNumber).HasMaxLength(50);
            builder.Property(p => p.Fax).HasMaxLength(50);
            builder.Property(p => p.Cellphone).HasMaxLength(50);
            builder.Property(p => p.Address).HasMaxLength(1000);

            //builder.HasMany(a => a.Comments).WithOne(b => b.Company).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Documents).WithOne(b => b.Company).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Links).WithOne(b => b.Company).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Medias).WithOne(b => b.Company).HasForeignKey(b => b.ReferenceId);
            //builder.HasOne(a => a.Location).WithOne(b => b.Company).HasForeignKey<Location>(b => b.ReferenceId);
            //builder.HasOne(a => a.Cost).WithOne(b => b.Company).HasForeignKey<Cost>(b => b.ReferenceId);

            //builder.HasMany(a => a.Employees).WithOne(b => b.Company);
            //ShadowProperty HasForeignKey Ro tolid mikone to EF
            //builder.HasMany(a => a.Profiles).WithOne(b => b.Company).HasForeignKey(p => p.CompanyRef);
        }
    }


    public enum CompanyType
    {
        [Display(Name = "SoleTrader", ResourceType = typeof(DataAnnotationsResources))]
        SoleTrader = 1,

        [Display(Name = "Partnership", ResourceType = typeof(DataAnnotationsResources))]
        Partnership = 2,

        [Display(Name = "Comapny", ResourceType = typeof(DataAnnotationsResources))]
        Comapny = 3,

        [Display(Name = "Trust", ResourceType = typeof(DataAnnotationsResources))]
        Trust = 4
    }
}
