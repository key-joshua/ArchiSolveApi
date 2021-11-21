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
    public class ProjectExtensionViewModel
    {
        [HiddenInput]
        [Key]
        public int ProjectExtensionId { get; set; }

        [HiddenInput]
        public int ProjectId { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Title")]
        public string Title { get; set; }

        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [StringLength(1000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Slagon")]
        public string Slagon { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [Url(ErrorMessage = "URL Is Not Valid")]
        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("URL")]
        public string URL { get; set; }

        [DisplayName("IsPublished")]
        public bool IsPublished { get; set; }

        public int? ListOrder { get; set; }



    }
}
