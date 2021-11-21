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
    public class PageViewModel
    {
        [Key]
        [HiddenInput]
        public int PageId { get; set; }

        [HiddenInput]
        public long? ObjectId { get; set; }

        [HiddenInput]
        public int? ParentId { get; set; }

        [Required]
        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Code")]
        public string Code { get; set; }

        [Required]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Title")]
        public string Title { get; set; }

        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [AllowHtml]
        [DisplayName("Description")]
        public string Description { get; set; }

        public int? ListOrder { get; set; }
    }
}
