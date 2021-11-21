using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;

namespace Entities
{
    public class Media : BaseEntity<int>
    {
        public int ReferenceId { get; set; }
        public ObjectType? ObjectType { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string SourceFileName { get; set; }
        public string URL { get; set; }
        public MediaType MediaType { get; set; }
        public SizeType? SizeType { get; set; }
        public decimal? Price { get; set; }
        public bool? IsIcon { get; set; }
        public string Note { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }

        //public virtual Project Project { get; set; }
        //public virtual ProjectExtension ProjectExtension { get; set; }
        //public virtual Content Content { get; set; }
        //public virtual Company Company { get; set; }
        //public virtual Group Group { get; set; }
        //public virtual Page Page { get; set; }
        //public virtual Profile Profile { get; set; }
    }

    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(500);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.SourceFileName).IsRequired();
            builder.Property(p => p.URL).HasMaxLength(3000);
            builder.Property(p => p.Note).HasMaxLength(500);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

            //builder.HasOne(a => a.ObjectTRef).WithOne(b => b.MediaRelated).HasForeignKey<Object>(b => b.MediaRelatedRef);
            //builder.HasOne(a => a.ObjectMedia).WithOne(b => b.MediaTRef).HasForeignKey<ObjectMedia>(b => b.MediaRef);
        }
    }

    public enum MediaType
    {
        [Display(Name = "Image", ResourceType = typeof(DataAnnotationsResources))]
        Image = 1,

        [Display(Name = "Audio", ResourceType = typeof(DataAnnotationsResources))]
        Audio = 2,

        [Display(Name = "Video", ResourceType = typeof(DataAnnotationsResources))]
        Video = 3,

        [Display(Name = "File", ResourceType = typeof(DataAnnotationsResources))]
        File = 4,
    }

    public enum SizeType
    {
        [Display(Name = "TitleImage", ResourceType = typeof(DataAnnotationsResources))]
        Title = 1,

        [Display(Name = "BodyImage", ResourceType = typeof(DataAnnotationsResources))]
        Body = 2,

        [Display(Name = "IconImage", ResourceType = typeof(DataAnnotationsResources))]
        Icon = 3,

        [Display(Name = "ThumbnailImage", ResourceType = typeof(DataAnnotationsResources))]
        Thumbnail = 4,
    }
}
