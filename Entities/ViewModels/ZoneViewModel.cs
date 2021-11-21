using Entities.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ArchiSolve.Models.ViewModels
{
    public class ZoneViewModel
    {
        [Key]
        [HiddenInput]
        public int ZoneId { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [Required]
        [DisplayName("Code")]
        public string ZoneCode { get; set; }

        [StringLength(200, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Title")]
        public string Title { get; set; }

        [StringLength(10, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        public string Culture { get; set; }
    }
}
