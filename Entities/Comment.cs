using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Resources;

namespace Entities
{
    public class Comment : BaseEntity<int>
    {
        public int? ReferenceId { get; set; }
        public ObjectType? ObjectType { get; set; }
        public RoleType? Role { get; set; }
        public int? NoCount { get; set; }
        public int? YesCount { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderIP { get; set; }
        public string SenderUrl { get; set; }
        public int? RoomId { get; set; }
        public string RoomName { get; set; }
        public string SenderTitle { get; set; }
        public string SenderFullName { get; set; }
        public string SenderEmail { get; set; }
        public string SourceFileName { get; set; }
        public string Note { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public int? ProfileRef { get; set; }
        public int? ParentRef { get; set; }
        public virtual Comment ParentComment { get; set; }
        public ICollection<Comment> ChildComments { get; set; }

        //public virtual Project Project { get; set; }
        //public virtual ProjectExtension ProjectExtension { get; set; }
        //public virtual Content Content { get; set; }
        //public virtual Company Company { get; set; }
        //public virtual Group Group { get; set; }
        //public virtual Page Page { get; set; }
        //public virtual Profile Profile { get; set; }


    }

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.Property(p => p.Subject).HasMaxLength(400);
            builder.Property(p => p.Body).IsRequired().HasMaxLength(2000);
            builder.Property(p => p.SenderIP).HasMaxLength(100);
            builder.Property(p => p.Note).HasMaxLength(500);
            builder.Property(p => p.SenderEmail).HasMaxLength(300);
            builder.Property(p => p.SenderFullName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.SenderUrl).HasMaxLength(3000);

            builder.HasOne(p => p.ParentComment).WithMany(c => c.ChildComments).HasForeignKey(p => p.ParentRef);
        }
    }

    public enum RoleType
    {
        [Display(Name = "Admin", ResourceType = typeof(DataAnnotationsResources))]
        Admin = 1,

        [Display(Name = "RegisteredUser", ResourceType = typeof(DataAnnotationsResources))]
        Registered = 2

    }
}
