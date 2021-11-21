using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;

namespace Entities
{
    public class User : IdentityUser<int> , IEntity
    {
        public User()
        {
            IsActive = false;
            UserType = UserType.Website;
        }

        public UserType UserType { get; set; }
        public bool IsActive { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public virtual Profile Profile { get; set; }
        //public virtual Entities.UserRole UserRole { get; set; }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PasswordHash).IsRequired();

            builder.HasOne(a => a.Profile).WithOne(b => b.User).HasForeignKey<Profile>(b => b.UserRef);

            //builder.HasOne(bc => bc.UserRole).WithOne(b => b.User).HasForeignKey<Entities.UserRole>(b => b.UserRef);


        }
    }

    public enum UserType
    {
        [Display(Name = "Admin", ResourceType = typeof(DataAnnotationsResources))]
        Admin = 1,

        [Display(Name = "Website", ResourceType = typeof(DataAnnotationsResources))]
        Website = 2
    }

    public enum UserRole
    {
        [Display(Name = "FullAccess", ResourceType = typeof(DataAnnotationsResources))]
        FullAccess = 1,

        [Display(Name = "PartialAccess", ResourceType = typeof(DataAnnotationsResources))]
        Website = 2
    }


}
