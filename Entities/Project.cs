using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;

namespace Entities
{
    public class Project : BaseEntity<int>
    {
        public string Title { get; set; }
        public ProjectType? ProjectType { get; set; }
        public ProjectClass? ProjectClass { get; set; }
        public BuilderType? BuilderType { get; set; }
        public ProjectStatus? ProjectStatus { get; set; }
        public string ShortDescription { get; set; }
        public string Slagon { get; set; }
        public string Resources { get; set; }
        public string ExtraDescription { get; set; }
        public string Description { get; set; }
        public DateTime? ProjectStartDateTime { get; set; }
        public DateTime? ProjectEndDateTime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public string Culture { get; set; }
        public ICollection<ProjectExtension> ProjectExtensions { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual Location Location { get; set; }
        public virtual Cost Cost { get; set; }
        public virtual ICollection<Media> Medias { get; set; }


    }

    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Slagon).HasMaxLength(1000);
            builder.Property(p => p.ShortDescription).HasMaxLength(3000);
            builder.Property(p => p.Resources).HasMaxLength(3000);
            builder.Property(p => p.ExtraDescription).HasMaxLength(3000);

            //builder.HasOne(a => a.Object).WithOne(b => b.Project).HasForeignKey<Object>(b => b.ProjectRef);
            builder.HasMany(a => a.ProjectExtensions).WithOne(b => b.Project).HasForeignKey(b => b.ProjectRef);

            //builder.HasMany(a => a.Comments).WithOne(b => b.Project).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Documents).WithOne(b => b.Project).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Links).WithOne(b => b.Project).HasForeignKey(b => b.ReferenceId);
            //builder.HasMany(a => a.Medias).WithOne(b => b.Project).HasForeignKey(b => b.ReferenceId);
            //builder.HasOne(a => a.Location).WithOne(b => b.Project).HasForeignKey<Location>(b => b.ReferenceId);
            //builder.HasOne(a => a.Cost).WithOne(b => b.Project).HasForeignKey<Cost>(b => b.ReferenceId);

            //builder.HasMany(a => a.Employees).WithOne(b => b.Project).HasForeignKey(p => p.ProjectRef);



        }
    }

    public enum ProjectType
    {
        [Display(Name = "House", ResourceType = typeof(DataAnnotationsResources))]
        House = 1,
        [Display(Name = "Unit", ResourceType = typeof(DataAnnotationsResources))]
        Unit = 2,
        [Display(Name = "TownHouse", ResourceType = typeof(DataAnnotationsResources))]
        TownHouse = 3,
        [Display(Name = "Villas", ResourceType = typeof(DataAnnotationsResources))]
        Villas = 4,
        [Display(Name = "ResidentialCareBuilding", ResourceType = typeof(DataAnnotationsResources))]
        Residential = 5,
        [Display(Name = "Offices", ResourceType = typeof(DataAnnotationsResources))]
        Offices = 6,
        [Display(Name = "Shops", ResourceType = typeof(DataAnnotationsResources))]
        Shops = 7,
        [Display(Name = "Cafe", ResourceType = typeof(DataAnnotationsResources))]
        Cafe = 8,
        [Display(Name = "Restaurant", ResourceType = typeof(DataAnnotationsResources))]
        Restaurant = 9,
        [Display(Name = "CarParks", ResourceType = typeof(DataAnnotationsResources))]
        CarParks = 10,
        [Display(Name = "Warehouses", ResourceType = typeof(DataAnnotationsResources))]
        Warehouses = 11,
        [Display(Name = "HealthCare", ResourceType = typeof(DataAnnotationsResources))]
        HealthCare = 12,
        [Display(Name = "AgedCare", ResourceType = typeof(DataAnnotationsResources))]
        AgedCare = 13,
        [Display(Name = "Motel", ResourceType = typeof(DataAnnotationsResources))]
        Motel = 14,
        [Display(Name = "Hotel", ResourceType = typeof(DataAnnotationsResources))]
        Hotel = 15,
        [Display(Name = "School", ResourceType = typeof(DataAnnotationsResources))]
        School = 16,
        [Display(Name = "PrivateGarage", ResourceType = typeof(DataAnnotationsResources))]
        PrivateGarage = 17,
        [Display(Name = "BushfireShelter", ResourceType = typeof(DataAnnotationsResources))]
        BushfireShelter = 18,
        [Display(Name = "SwimmingPool", ResourceType = typeof(DataAnnotationsResources))]
        SwimmingPool = 19,
        [Display(Name = "Sheds", ResourceType = typeof(DataAnnotationsResources))]
        Sheds = 20,
        [Display(Name = "Factory", ResourceType = typeof(DataAnnotationsResources))]
        Factory = 21,
        [Display(Name = "Labratory", ResourceType = typeof(DataAnnotationsResources))]
        Labratory = 22,
        [Display(Name = "Jails", ResourceType = typeof(DataAnnotationsResources))]
        Jails = 23,

    }

    public enum ProjectClass
    {
        [Display(Name = "Class1", ResourceType = typeof(DataAnnotationsResources))]
        Class1 = 1,
        [Display(Name = "Class1a", ResourceType = typeof(DataAnnotationsResources))]
        Class1a = 2,
        [Display(Name = "Class1b", ResourceType = typeof(DataAnnotationsResources))]
        Class1b = 3,
        [Display(Name = "Class2", ResourceType = typeof(DataAnnotationsResources))]
        Class2 = 4,
        [Display(Name = "Class3", ResourceType = typeof(DataAnnotationsResources))]
        Class3 = 5,
        [Display(Name = "Class4", ResourceType = typeof(DataAnnotationsResources))]
        Class4 = 6,
        [Display(Name = "Class5", ResourceType = typeof(DataAnnotationsResources))]
        Class5 = 7,
        [Display(Name = "Class6", ResourceType = typeof(DataAnnotationsResources))]
        Class6 = 8,
        [Display(Name = "Class7", ResourceType = typeof(DataAnnotationsResources))]
        Class7 = 9,
        [Display(Name = "Class7a", ResourceType = typeof(DataAnnotationsResources))]
        Class7a = 10,
        [Display(Name = "Class7b", ResourceType = typeof(DataAnnotationsResources))]
        Class7b = 11,
        [Display(Name = "Class8", ResourceType = typeof(DataAnnotationsResources))]
        Class8 = 12,
        [Display(Name = "Class9", ResourceType = typeof(DataAnnotationsResources))]
        Class9 = 13,
        [Display(Name = "Class9a", ResourceType = typeof(DataAnnotationsResources))]
        Class9a = 14,
        [Display(Name = "Class9b", ResourceType = typeof(DataAnnotationsResources))]
        Class9b = 15,
        [Display(Name = "Class9c", ResourceType = typeof(DataAnnotationsResources))]
        Class9c = 16,
        [Display(Name = "Class10", ResourceType = typeof(DataAnnotationsResources))]
        Class10 = 17,
        [Display(Name = "Class10a", ResourceType = typeof(DataAnnotationsResources))]
        Class10a = 18,
        [Display(Name = "Class10b", ResourceType = typeof(DataAnnotationsResources))]
        Class10b = 19,
        [Display(Name = "Class10c", ResourceType = typeof(DataAnnotationsResources))]
        Class10c = 20,
    }

    public enum BuilderType
    {
        [Display(Name = "LowRise", ResourceType = typeof(DataAnnotationsResources))]
        LowRise = 1,
        [Display(Name = "MediumRise", ResourceType = typeof(DataAnnotationsResources))]
        MediumRise = 2,
        [Display(Name = "HighRise", ResourceType = typeof(DataAnnotationsResources))]
        HighRise = 3,
        [Display(Name = "Open", ResourceType = typeof(DataAnnotationsResources))]
        Open = 4,
    }
    public enum ProjectStatus
    {
        [Display(Name = "Negotiating", ResourceType = typeof(DataAnnotationsResources))]
        Negotiating = 1,
        [Display(Name = "Preparing", ResourceType = typeof(DataAnnotationsResources))]
        Preparing = 2,
        [Display(Name = "InProgress", ResourceType = typeof(DataAnnotationsResources))]
        InProgress = 3,
        [Display(Name = "Finishing", ResourceType = typeof(DataAnnotationsResources))]
        Finishing = 4,
        [Display(Name = "Finished", ResourceType = typeof(DataAnnotationsResources))]
        Finished = 5,
    }
    }
