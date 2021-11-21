using Entities.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Entities
{
    public class Profile : BaseEntity<int>
    {
        public string Title { get; set; }
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public EducationDegree? EducationDegree { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }
        public string HomeCall { get; set; }
        public string WorkCall { get; set; }
        public string Cellphone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public ProfileType? ProfileType { get; set; }
        public string AcademicRank { get; set; }
        public string CertificatePlace { get; set; }
        public string Skills { get; set; }
        public string ShortDescription { get; set; }
        public string Department { get; set; }
        public string Biography { get; set; }
        public string Favorites { get; set; }
        public bool IsVisible { get; set; }
        public string NationalCode { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public bool? HasCleanRecord { get; set; }
        public bool? IsCompleted { get; set; }
        public int? UserRef { get; set; }
        public User User { get; set; }

        public int? CompanyRef { get; set; }
        public virtual Company Company { get; set; }
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

    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(100);
            builder.Property(p => p.JobTitle).HasMaxLength(100);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.MiddleName).HasMaxLength(100);
            builder.Property(p => p.Address).HasMaxLength(500);
            builder.Property(p => p.WorkAddress).HasMaxLength(500);
            builder.Property(p => p.Cellphone).HasMaxLength(50);
            builder.Property(p => p.HomeCall).HasMaxLength(50);
            builder.Property(p => p.WorkCall).HasMaxLength(50);
            builder.Property(p => p.Website).HasMaxLength(3000);
            builder.Property(p => p.Email).HasMaxLength(300);
            builder.Property(p => p.AcademicRank).HasMaxLength(300);
            builder.Property(p => p.CertificatePlace).HasMaxLength(100);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.NationalCode).HasMaxLength(20);
            builder.Property(p => p.DrivingLicenseNumber).HasMaxLength(20);

            //builder.HasOne(a => a.Object).WithOne(b => b.Profile).HasForeignKey<Object>(b => b.ProfileRef);
            //builder.HasOne(a => a.ObjectProfile).WithOne(b => b.ProfileTRef).HasForeignKey<ObjectProfile>(b => b.ProfileRef);

            //builder.HasMany(a => a.Comments).WithOne(b => b.Profile).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Documents).WithOne(b => b.Profile).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Links).WithOne(b => b.Profile).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Medias).WithOne(b => b.Profile).HasForeignKey(b => b.ReferenceId);
            //builder.HasOne(a => a.Location).WithOne(b => b.Profile).HasForeignKey<Location>(b => b.ReferenceId);
            //builder.HasOne(a => a.Cost).WithOne(b => b.Profile).HasForeignKey<Cost>(b => b.ReferenceId);


        }
    }

    public enum Gender
    {
        [Display(Name = "Male", ResourceType = typeof(DataAnnotationsResources))]
        Male = 1,
        [Display(Name = "Female", ResourceType = typeof(DataAnnotationsResources))]
        Female = 2,
        [Display(Name = "NonBinary", ResourceType = typeof(DataAnnotationsResources))]
        NonBinary = 3,
        [Display(Name = "Transgender", ResourceType = typeof(DataAnnotationsResources))]
        Transgender = 4,
        [Display(Name = "Intersex", ResourceType = typeof(DataAnnotationsResources))]
        Intersex = 5,
        [Display(Name = "Other", ResourceType = typeof(DataAnnotationsResources))]
        Other = 6,
        [Display(Name = "IPreferNotToSay", ResourceType = typeof(DataAnnotationsResources))]
        IPreferNotToSay = 7,

    }

    public enum EducationDegree
    {
        [Display(Name = "CertificateI", ResourceType = typeof(DataAnnotationsResources))]
        CertificateI = 1,

        [Display(Name = "CertificateII", ResourceType = typeof(DataAnnotationsResources))]
        CertificateII = 2,

        [Display(Name = "CertificateIII", ResourceType = typeof(DataAnnotationsResources))]
        CertificateIII = 3,

        [Display(Name = "CertificateIV", ResourceType = typeof(DataAnnotationsResources))]
        CertificateIV = 4,

        [Display(Name = "Diploma", ResourceType = typeof(DataAnnotationsResources))]
        Diploma = 5,

        [Display(Name = "AssociateDegree", ResourceType = typeof(DataAnnotationsResources))]
        AssociateDegree = 6,

        [Display(Name = "AdvancedDiploma", ResourceType = typeof(DataAnnotationsResources))]
        AdvancedDiploma = 7,

        [Display(Name = "BachelorDegree", ResourceType = typeof(DataAnnotationsResources))]
        BachelorDegree = 8,

        [Display(Name = "GraduateDiploma", ResourceType = typeof(DataAnnotationsResources))]
        GraduateDiploma = 9,

        [Display(Name = "GraduateCertificate", ResourceType = typeof(DataAnnotationsResources))]
        GraduateCertificate = 10,

        [Display(Name = "BachelorHonoursDegree", ResourceType = typeof(DataAnnotationsResources))]
        BachelorHonoursDegree = 11,

        [Display(Name = "MastersDegree", ResourceType = typeof(DataAnnotationsResources))]
        MastersDegree = 12,

        [Display(Name = "MastersDegreeExtended", ResourceType = typeof(DataAnnotationsResources))]
        MastersDegreeExtended = 13,

        [Display(Name = "MastersDegreeCoursework", ResourceType = typeof(DataAnnotationsResources))]
        MastersDegreeCoursework = 14,

        [Display(Name = "MastersDegreeResearch", ResourceType = typeof(DataAnnotationsResources))]
        MastersDegreeResearch = 15,

        [Display(Name = "DoctoralDegree", ResourceType = typeof(DataAnnotationsResources))]
        DoctoralDegree = 16,
    }
    public enum ProfileType
    {
        [Display(Name = "Created", ResourceType = typeof(DataAnnotationsResources))]
        Created = 1,

        [Display(Name = "Registered", ResourceType = typeof(DataAnnotationsResources))]
        Registered = 2
    }

}
