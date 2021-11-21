using Entities.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Group : BaseEntity<int>
    {
      
        public string Title { get; set; }
        public string Code { get; set; }
        public GroupType Type { get; set; }
        public ObjectType ObjectType { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int? ListOrder { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public string Culture { get; set; }
        public int SectionRef { get; set; }
        public virtual Section Section { get; set; }
        
        public int? ParentId { get; set; }
        public Group ParentGroup { get; set; }
        public ICollection<Group> ChildGroups { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual Location Location { get; set; }
        public virtual Cost Cost { get; set; }
        public virtual ICollection<Media> Medias { get; set; }

    }

    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(p => p.Type).HasDefaultValue(GroupType.Static);

            builder.Property(p => p.Code).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(500);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);

           
            builder.HasOne(p => p.ParentGroup).WithMany(c => c.ChildGroups).HasForeignKey(p => p.ParentId);

            //builder.HasMany(a => a.Comments).WithOne(b => b.Group).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Documents).WithOne(b => b.Group).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Links).WithOne(b => b.Group).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Medias).WithOne(b => b.Group).HasForeignKey(b => b.ReferenceId);
            //builder.HasOne(a => a.Location).WithOne(b => b.Group).HasForeignKey<Location>(b => b.ReferenceId);
            //builder.HasOne(a => a.Cost).WithOne(b => b.Group).HasForeignKey<Cost>(b => b.ReferenceId);


        }
    }

    public enum GroupType
    {
        [Display(Name = "Static", ResourceType = typeof(DataAnnotationsResources))]
        Static = 1,

        [Display(Name = "Service", ResourceType = typeof(DataAnnotationsResources))]
        Service = 2

    }

    public enum ObjectType
    {
     

        [Display(Name = "Page", ResourceType = typeof(DataAnnotationsResources))]
        Page = 1,

        [Display(Name = "Content", ResourceType = typeof(DataAnnotationsResources))]
        Content = 2,

        [Display(Name = "Profile", ResourceType = typeof(DataAnnotationsResources))]
        Profile = 3,

        [Display(Name = "Group", ResourceType = typeof(DataAnnotationsResources))]
        Group = 4,

        [Display(Name = "Project", ResourceType = typeof(DataAnnotationsResources))]
        Project = 5,

        [Display(Name = "ProjectExtension", ResourceType = typeof(DataAnnotationsResources))]
        ProjectExtension = 6,

        [Display(Name = "Comapny", ResourceType = typeof(DataAnnotationsResources))]
        Comapny = 7,

        [Display(Name = "Banner", ResourceType = typeof(DataAnnotationsResources))]
        Banner = 8,

        [Display(Name = "Loan", ResourceType = typeof(DataAnnotationsResources))]
        Loan = 9,




    }
}
