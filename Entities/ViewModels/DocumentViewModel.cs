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
    public class DocumentViewModel
    {
        [Key]
        [HiddenInput]
        public int DocumentId { get; set; }
        [HiddenInput]
        public long? ObjectId { get; set; }

        [Required]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Title")]
        public string Title { get; set; }


        [DisplayName("Type")]
        [Range(1, 50, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        public byte? Type { get; set; }


        [DisplayName("Status")]
        [Range(1, 50, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        public byte? Status { get; set; }


        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Institution")]
        public string Institution { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Issue Number")]
        public string IssueNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        [DisplayName("Isuue Date")]
        public DateTime? IsuueDateTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:D}")]
        [DisplayName("Expirtation Date")]
        public DateTime? ValidityExpirtationDateTime { get; set; }

        
    }
}
