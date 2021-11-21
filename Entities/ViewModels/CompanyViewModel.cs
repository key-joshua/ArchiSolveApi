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
    public class CompanyViewModel
    {
        [Key]
        [HiddenInput]
        public int CompanyId { get; set; }

        [HiddenInput]
        public long? ObjectId { get; set; }

        [Required]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [StringLength(200, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Title")]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Slagon")]
        public string Slagon { get; set; }

        [DisplayName("Type")]
        [Range(1, 20, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        public byte? Type { get; set; }

        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [AllowHtml]
        [DisplayName("Description")]
        public string Description { get; set; }


        [Url(ErrorMessage = "URL Is Not Valid")]
        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Website")]
        public string Website { get; set; }


        [EmailAddress(ErrorMessage = "Email Address Is Not Valid")]
        [StringLength(300, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Email")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Primary Phone Number")]
        public string PrimaryPhoneNumber { get; set; }

        [StringLength(5, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Secondary Phone Number")]
        public string SecondaryPhoneNumber { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Fax")]
        public string Fax { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Cellphone")]
        public string Cellphone { get; set; }

        [StringLength(1000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        [DisplayName("Stablish DateTime")]
        public DateTime? StablishDateTime { get; set; }

        [DisplayName("StartCooperation DateTime")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime? StartCooperationDateTime { get; set; }

        [DisplayName("EndCooperation DateTime")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime? EndCooperationDateTime { get; set; }


    }
}
