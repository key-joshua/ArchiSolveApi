using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;

namespace Entities
{
    public class Calculator : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public CalculatorType? CalculatorType { get; set; }
        public string Icon { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public string Culture { get; set; }
    }

    public class CalculatorConfiguration : IEntityTypeConfiguration<Calculator>
    {
        public void Configure(EntityTypeBuilder<Calculator> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(500);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.SEOTitle).HasMaxLength(60);
            builder.Property(p => p.SEODescription).HasMaxLength(155);
        }
    }

    public enum CalculatorType
    {
        [Display(Name = "Loan", ResourceType = typeof(DataAnnotationsResources))]
        Loan = 1,
        [Display(Name = "Personal", ResourceType = typeof(DataAnnotationsResources))]
        Personal = 2
    }


}
