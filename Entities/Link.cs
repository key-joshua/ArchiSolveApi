using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;
using System;

namespace Entities
{
    public class Link : BaseEntity<int>
    {
        public int ReferenceId { get; set; }
        public ObjectType? ObjectType { get; set; }
        public string Title { get; set; }
        public string BottomTitle { get; set; }
        public string ShortDescription { get; set; }
        public ReservedTitle? ReservedTitle { get; set; }
        public LinkType? Type { get; set; }
        public string URL { get; set; }
        public bool? IsPublished { get; set; }

        //public virtual Project Project { get; set; }
        //public virtual ProjectExtension ProjectExtension { get; set; }
        //public virtual Content Content { get; set; }
        //public virtual Company Company { get; set; }
        //public virtual Group Group { get; set; }
        //public virtual Page Page { get; set; }
        //public virtual Profile Profile { get; set; }

    }


    public class LinkConfiguration : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.Property(p => p.IsPublished).HasDefaultValue(true);

            builder.Property(p => p.Title).HasMaxLength(400);
            builder.Property(p => p.BottomTitle).HasMaxLength(400);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.URL).IsRequired().HasMaxLength(3000);
        }
    }

    public enum LinkType
    {
        [Display(Name = "WebsiteLink", ResourceType = typeof(DataAnnotationsResources))]
        WebsiteLink = 1,

        [Display(Name = "AppLink", ResourceType = typeof(DataAnnotationsResources))]
        AppLink = 2,

        [Display(Name = "SocialMedia", ResourceType = typeof(DataAnnotationsResources))]
        SocialMedia = 3,

        [Display(Name = "EmailLink", ResourceType = typeof(DataAnnotationsResources))]
        EmailLink = 4,
    }

    public enum ReservedTitle
    {
        [Display(Name = "LinkedIn", ResourceType = typeof(DataAnnotationsResources))]
        LinkedIn = 1,

        [Display(Name = "Facebook", ResourceType = typeof(DataAnnotationsResources))]
        Facebook = 2,

        [Display(Name = "Intstagram", ResourceType = typeof(DataAnnotationsResources))]
        Intstagram = 3,

        [Display(Name = "Twitter", ResourceType = typeof(DataAnnotationsResources))]
        Twitter = 4,

        [Display(Name = "YouTube", ResourceType = typeof(DataAnnotationsResources))]
        YouTube = 5,

        [Display(Name = "Skype", ResourceType = typeof(DataAnnotationsResources))]
        Skype = 6,

        [Display(Name = "WhatsApp", ResourceType = typeof(DataAnnotationsResources))]
        WhatsApp = 7,

        [Display(Name = "WeChat", ResourceType = typeof(DataAnnotationsResources))]
        WeChat = 8,

        [Display(Name = "Snapchat", ResourceType = typeof(DataAnnotationsResources))]
        Snapchat = 9,

        [Display(Name = "Tumblr", ResourceType = typeof(DataAnnotationsResources))]
        Tumblr = 10,

        [Display(Name = "Telegram", ResourceType = typeof(DataAnnotationsResources))]
        Telegram = 11,

        [Display(Name = "Viber", ResourceType = typeof(DataAnnotationsResources))]
        Viber = 12,

        [Display(Name = "Line", ResourceType = typeof(DataAnnotationsResources))]
        Line = 13,

        [Display(Name = "Pinterest", ResourceType = typeof(DataAnnotationsResources))]
        Pinterest = 14,

        [Display(Name = "Reddit", ResourceType = typeof(DataAnnotationsResources))]
        Reddit = 15,

        [Display(Name = "TikTok", ResourceType = typeof(DataAnnotationsResources))]
        TikTok = 16,

    }
}
