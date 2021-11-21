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
    public class ProfileViewModel
    {
        [Key]
        [HiddenInput]
        public int ProfileId { get; set; }

        [HiddenInput]
        public long? ObjeactId { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Title")]
        public string Title { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Range(1, 20, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Gender")]
        public byte? Gender { get; set; }


        [DisplayName("Date Of Birth")]
        public DateTime? Birthday { get; set; }

        [Range(1, 20, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Educational Degree")]
        public byte? EducationDegree { get; set; }

        [HiddenInput]
        public int? LocationId { get; set; }

        [DisplayName("Address")]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        public string Address { get; set; }

        [HiddenInput]
        public int? WorkLocationId { get; set; }

        [DisplayName("Work Address")]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        public string WorkAddress { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Home Phone Number")]
        public string HomeCall { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Work Phone Number")]
        public string WorkCall { get; set; }


        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Cellphone")]
        public string Cellphone { get; set; }

        [Url(ErrorMessage = "URL Is Not Valid")]
        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Website")]
        public string Website { get; set; }

        [EmailAddress(ErrorMessage = "Email Address Is Not Valid")]
        [StringLength(300, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Range(1, 20, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Type")]
        public byte? Type { get; set; }

        [StringLength(300, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Academic Rank")]
        public string AcademicRank { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Certificate Place")]
        public string CertificatePlace { get; set; }

        [DisplayName("Skills")]
        public string Skills { get; set; }

        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [DisplayName("Department")]
        public string Department { get; set; }

        [DisplayName("Biography")]
        public string Biography { get; set; }


        [DisplayName("Favorites")]
        public string Favorites { get; set; }


        [DisplayName("Is Visible")]
        public bool IsVisible { get; set; }

        [StringLength(20, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("National Code")]
        public string NationalCode { get; set; }

        [StringLength(20, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Driving License Number")]
        public string DrivingLicenseNumber { get; set; }

        [DisplayName("Has Clean Record")]
        public bool? HasCleanRecord { get; set; }

        [DisplayName("Is Completed")]
        public bool? IsCompleted { get; set; }

    }
}
