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
    public class ProjectViewModel
    {

        
        //public virtual Genre Genre { get; set; }
        //public virtual Artist Artist { get; set; }
        [Key]
        [HiddenInput]
        public int ProjectId { get; set; }

        [HiddenInput]
        public long? ObjectId { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Range(1, 20, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Type")]
        public byte? Type { get; set; }

        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [StringLength(1000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Slagon")]
        public string Slagon { get; set; }

        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Resources")]
        public string Resources { get; set; }

        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Extra Description")]
        public string ExtraDescription { get; set; }

        [AllowHtml]
        [DisplayName("Description")]
        public string Description { get; set; }

        [HiddenInput]
        public int? LocationId { get; set; }

        [DisplayName("Project Start Date")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime? ProjectStartDateTime { get; set; }

        [DisplayName("Project End Date")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime? ProjectEndDateTime { get; set; }

    }
}
