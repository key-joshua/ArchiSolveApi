using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;

namespace Entities
{
    public class Document : BaseEntity<int>
    {
        public int ReferenceId { get; set; }
        public ObjectType? ObjectType { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Institution { get; set; }
        public string IssueNumber { get; set; }
        public DocumentType? Type { get; set; }
        public DocumentStatus? Status { get; set; }
        public DateTime? ValidityStartDateTime { get; set; }
        public DateTime? ValidityExpirtationDateTime { get; set; }
        public string SourceFileName { get; set; }
        public string URL { get; set; }
        public MediaType MediaType { get; set; }
        //public virtual Project Project { get; set; }
        //public virtual ProjectExtension ProjectExtension { get; set; }
        //public virtual Content Content { get; set; }
        //public virtual Company Company { get; set; }
        //public virtual Group Group { get; set; }
        //public virtual Page Page { get; set; }
        //public virtual Profile Profile { get; set; }
    }


    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(500);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.Institution).HasMaxLength(500);
            builder.Property(p => p.IssueNumber).HasMaxLength(100);

            //builder.HasOne(a => a.Object).WithOne(b => b.Document).HasForeignKey<Object>(b => b.DocumentRef);
            //builder.HasOne(a => a.ObjectTRef).WithOne(b => b.DocumentRelated).HasForeignKey<Object>(b => b.DocumentRelatedRef);
            //builder.HasOne(a => a.ObjectDocument).WithOne(b => b.DocumentTRef).HasForeignKey<ObjectDocument>(b => b.DocumentRef);
        }
    }

    public enum DocumentType
    {
        [Display(Name = "Licence", ResourceType = typeof(DataAnnotationsResources))]
        Licence = 1,

        [Display(Name = "PersonalID", ResourceType = typeof(DataAnnotationsResources))]
        PersonalID = 2
    }

    public enum DocumentStatus
    {
        [Display(Name = "Valid", ResourceType = typeof(DataAnnotationsResources))]
        Valid = 1,

        [Display(Name = "Expired", ResourceType = typeof(DataAnnotationsResources))]
        Expired = 2,

        [Display(Name = "InProgress", ResourceType = typeof(DataAnnotationsResources))]
        InProgress = 3
    }
}
