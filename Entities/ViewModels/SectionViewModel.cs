using Entities.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArchiSolve.Models
{
    public class SectionViewModel
    {
        [HiddenInput]
        [Key]
        public int SectionId { get; set; }

        [DisplayName("IsPublished")]
        public bool? IsPublished { get; set; }

        [StringLength(200, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Title")]
        public byte Title { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Code")]
        public byte Code { get; set; }

        [StringLength(10, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Culture")]
        public string Culture { get; set; }
    }
}
