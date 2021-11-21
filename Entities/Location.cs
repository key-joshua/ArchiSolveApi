using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using Entities.Resources;

namespace Entities
{
    public class Location: BaseEntity<int>
    {
        public int ReferenceId { get; set; }
        public ObjectType? ObjectType { get; set; }
        public string Title { get; set; }
        public LocationStatus? Status { get; set; }
        public LocationType? Type { get; set; }

        public string CountryName { get; set; }
        public int CountryRef { get; set; }
        public virtual Property CountryProperty { get; set; }

        public string StateName { get; set; }
        public int StateRef { get; set; }
        public virtual Property StateProperty { get; set; }

        public string CityName { get; set; }
        public int CityRef { get; set; }
        public virtual Property CityProperty { get; set; }

        public string SuburbName { get; set; }
        public int SuburbRef { get; set; }
        public virtual Property SuburbProperty { get; set; }

        public Decimal? Longitude { get; set; }
        public Decimal? Latitude { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }


        //public virtual Project Project { get; set; }
        //public virtual ProjectExtension ProjectExtension { get; set; }
        //public virtual Content Content { get; set; }
        //public virtual Company Company { get; set; }
        //public virtual Group Group { get; set; }
        //public virtual Page Page { get; set; }
        //public virtual Profile Profile { get; set; }

    }

    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(500);
            builder.Property(p => p.CountryName).HasMaxLength(50);
            builder.Property(p => p.StateName).HasMaxLength(100);
            builder.Property(p => p.CityName).HasMaxLength(100);
            builder.Property(p => p.SuburbName).HasMaxLength(100);
            builder.Property(p => p.PostalCode).HasMaxLength(30);
            builder.Property(p => p.Address).HasMaxLength(500);
            builder.Property(p => p.Longitude).HasColumnType("decimal(10,7)");
            builder.Property(p => p.Latitude).HasColumnType("decimal(10,7)");
            
            //builder.HasOne(a => a.ObjectTRef).WithOne(b => b.LocationRelated).HasForeignKey<Object>(b => b.LocationRelatedRef);
            //builder.HasOne(a => a.Profile).WithOne(b => b.Location).HasForeignKey<Profile>(b => b.LocationRef);
            // builder.HasOne(a => a.Company).WithOne(b => b.Location).HasForeignKey<Company>(b => b.LocationRef);
            //builder.HasOne(a => a.Project).WithOne(b => b.Location).HasForeignKey<Project>(b => b.LocationRef);
        }
    }

    public enum LocationType
    {

        [Display(Name = "Sustainable", ResourceType = typeof(DataAnnotationsResources))]
        Sustainable = 1,

        [Display(Name = "Industrial", ResourceType = typeof(DataAnnotationsResources))]
        Industrial = 2,

        [Display(Name = "Conservation", ResourceType = typeof(DataAnnotationsResources))]
        Conservation = 3,

        [Display(Name = "Landscape", ResourceType = typeof(DataAnnotationsResources))]
        Landscape = 4,

        [Display(Name = "Urban", ResourceType = typeof(DataAnnotationsResources))]
        Urban = 5,

        [Display(Name = "DistrictedArea", ResourceType = typeof(DataAnnotationsResources))]
        DistrictedArea = 6,
    }

    public enum LocationStatus
    {

        [Display(Name = "Builted", ResourceType = typeof(DataAnnotationsResources))]
        Sustainable = 1,

        [Display(Name = "EmptyLot", ResourceType = typeof(DataAnnotationsResources))]
        NotAvailable = 2,

        [Display(Name = "UnderConstruction", ResourceType = typeof(DataAnnotationsResources))]
        UnderConstruction = 3,
    }
    }
