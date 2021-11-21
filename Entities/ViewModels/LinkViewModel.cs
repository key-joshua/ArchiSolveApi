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
    public class LinkViewModel
    {
        [Key]
        [HiddenInput]
        public int LinkId { get; set; }

        [StringLength(400, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Title")]
        public string Title { get; set; }

        [StringLength(400, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Bottom Title")]
        public string BottomTitle { get; set; }

        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [Range(1, 128, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Reserved Title")]
        public byte? ReservedTitle { get; set; }

        [Range(1, 20, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Type")]
        public byte? Type { get; set; }

        [Required]
        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [Url(ErrorMessage = "URL Is Not Valid")]
        [DisplayName("URL")]
        public string URL { get; set; }

        [HiddenInput]
        public int? MediaId { get; set; }

        [DisplayName("IsPublished")]
        public bool IsPublished { get; set; }
    }
}
