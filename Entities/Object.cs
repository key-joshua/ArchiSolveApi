using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Resources;

namespace Entities
{
    public class Object : BaseEntity<long>
    {
        #region Objects
        public int CompanyRef { get; set; }
        public virtual Company Company { get; set; }

        public int ContentRef { get; set; }
        public virtual Content Content { get; set; }

        public int GroupRef { get; set; }
        public virtual Group Group { get; set; }

        public int PageRef { get; set; }
        public virtual Page Page { get; set; }

        public int ProfileRef { get; set; }
        public virtual Profile Profile { get; set; }

        public int ProjectRef { get; set; }
        public virtual Project Project { get; set; }
        #endregion

        #region Related to Objects

        public int ProjectExtensionRef { get; set; }
        public virtual ProjectExtension ProjectExtension { get; set; }
        
        public int CommentRelatedRef { get; set; }
        public virtual Comment CommentRelated { get; set; }

        public long CostRelatedRef { get; set; }
        public virtual Cost CostRelated { get; set; }

        public int DocumentRelatedRef { get; set; }
        public virtual Document DocumentRelated { get; set; }

        public int LinkRelatedRef { get; set; }
        public virtual Link LinkRelated { get; set; }

        public int LocationRelatedRef { get; set; }
        public virtual Location LocationRelated { get; set; }

        public int MediaRelatedRef { get; set; }
        public virtual Media MediaRelated { get; set; }
        #endregion

        #region Common
        public ObjectType Type { get; set; }
        public string Note { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public string Culture { get; set; }
        #endregion

        #region One-to-many Relationships
        //public ICollection<ObjectComment> ObjectComments { get; set; }
        //public ICollection<ObjectDocument> ObjectDocuments { get; set; }
        //public ICollection<ObjectLink> ObjectLinks { get; set; }
        //public ICollection<ObjectMedia> ObjectMedias { get; set; }
        public ICollection<ObjectProfile> ObjectProfiles { get; set; }
        #endregion
    }

    public class ObjectConfiguration : IEntityTypeConfiguration<Object>
    {
        public void Configure(EntityTypeBuilder<Object> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(p => p.Note).HasMaxLength(500);
            builder.Property(p => p.Culture).IsRequired().HasMaxLength(10);


            //builder.HasMany(a => a.ObjectComments).WithOne(b => b.ObjectTRef).HasForeignKey(b => b.ObjectRef);
            //builder.HasMany(a => a.ObjectDocuments).WithOne(b => b.ObjectTRef).HasForeignKey(b => b.ObjectRef);
            //builder.HasMany(a => a.ObjectLinks).WithOne(b => b.ObjectTRef).HasForeignKey(b => b.ObjectRef);
            //builder.HasMany(a => a.ObjectMedias).WithOne(b => b.ObjectTRef).HasForeignKey(b => b.ObjectRef);
            builder.HasMany(a => a.ObjectProfiles).WithOne(b => b.ObjectTRef).HasForeignKey(b => b.ObjectRef);

        }
    }

    public enum ObjectType
    {
        [Display(Name = "Banner", ResourceType = typeof(DataAnnotationsResources))]
        Banner = 1,

        [Display(Name = "Page", ResourceType = typeof(DataAnnotationsResources))]
        Page = 2,

        [Display(Name = "Content", ResourceType = typeof(DataAnnotationsResources))]
        Content = 3,

        [Display(Name = "Profile", ResourceType = typeof(DataAnnotationsResources))]
        Profile = 4,

        [Display(Name = "Group", ResourceType = typeof(DataAnnotationsResources))]
        Group = 5,

        [Display(Name = "Project", ResourceType = typeof(DataAnnotationsResources))]
        Project = 6,

        [Display(Name = "ProjectExtension", ResourceType = typeof(DataAnnotationsResources))]
        ProjectExtension = 7,

        [Display(Name = "Comapny", ResourceType = typeof(DataAnnotationsResources))]
        Comapny = 8,

        [Display(Name = "Document", ResourceType = typeof(DataAnnotationsResources))]
        Document = 9,

        [Display(Name = "Location", ResourceType = typeof(DataAnnotationsResources))]
        Location = 10,


    }
}
