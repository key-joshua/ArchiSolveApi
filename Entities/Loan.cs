using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;

namespace Entities
{
    public class Loan : BaseEntity<int>
    {
        public string Title { get; set; }
        public string BottomTitle { get; set; }
        public LoanType? LoanType { get; set; }
        public string ShortDescription { get; set; }
        public string Slagon { get; set; }
        public string SourceFileName { get; set; }
        public string Resources { get; set; }
        public string ExtraDescription { get; set; }
        public string Description { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public string Culture { get; set; }
    }

    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(500);
            builder.Property(p => p.BottomTitle).HasMaxLength(1000);
            builder.Property(p => p.Slagon).HasMaxLength(1000);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.Resources).HasMaxLength(3000);
            builder.Property(p => p.ExtraDescription).HasMaxLength(3000);
            builder.Property(p => p.SEOTitle).HasMaxLength(60);
            builder.Property(p => p.SEODescription).HasMaxLength(155);
        }
    }

    public enum LoanType
    {
        [Display(Name = "IAm", ResourceType = typeof(DataAnnotationsResources))]
        IAm = 1,
        [Display(Name = "LoanTypes", ResourceType = typeof(DataAnnotationsResources))]
        LoanTypes = 2,
        [Display(Name = "LoanHelp", ResourceType = typeof(DataAnnotationsResources))]
        LoanHelp = 3,
    }


}
