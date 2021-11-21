using Entities.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArchiSolve.Models.ViewModels
{
    public class LocationViewModel
    {
        [Key]
        [HiddenInput]
        public int LocationId { get; set; }

        [HiddenInput]
        public long? ObjectId { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Range(1, 128, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Status")]
        public byte? Status { get; set; }

        [Range(1, 20, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Type")]
        public byte? Type { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Country Name")]
        public string CountryName { get; set; }

        [HiddenInput]
        public int? CountryId { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("State Name")]
        public string StateName { get; set; }

        [HiddenInput]
        public int? StateId { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("City Name")]
        public string CityName { get; set; }

        [HiddenInput]
        public int? CityId { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Suburb Name")]
        public string SuburbName { get; set; }

        [HiddenInput]
        public int? SuburId { get; set; }

        [DisplayName("Longitude")]
        public Decimal? Longitude { get; set; }

        [DisplayName("Latitude")]
        public Decimal? Latitude { get; set; }

        [StringLength(30, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Address")]
        public string Address { get; set; }

    }
}
