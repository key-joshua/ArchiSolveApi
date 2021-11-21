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
    public class PropertyViewModel
    {
        [Key]
        [HiddenInput]
        public int PropertyId { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Title")]
        public string Title { get; set; }

        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Code")]
        public string Code { get; set; }

        [Required]
        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Value")]
        public string Value { get; set; }

        [DisplayName("IsPublieshed")]
        public bool IsPublieshed { get; set; }

        [DisplayName("Creation Date Time")]
        public DateTime? CreationDateTime { get; set; }

        [DisplayName("Last Modified Date Time")]
        public DateTime? LastModifiedDateTime { get; set; }

        public int? ListOrder { get; set; }

        [Range(1, 10)]
        public string Culture { get; set; }
    }
}
