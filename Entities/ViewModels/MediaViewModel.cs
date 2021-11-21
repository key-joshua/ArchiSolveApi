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
    public class MediaViewModel
    {
        [Key]
        [HiddenInput]
        public long MediaId { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Title")]
        public string Title { get; set; }

        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [HiddenInput]
        public long? OwnerObjectId { get; set; }

        [Required]
        public string SourceFileName { get; set; }

        [Url(ErrorMessage = "URL Is Not Valid")]
        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("URL")]
        public string Url { get; set; }

        [Range(1, 20, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Type")]
        public byte Type { get; set; }

        [DisplayName("Price")]
        public decimal? Price { get; set; }

        [DisplayName("Is Icon")]
        public bool? IsIcon { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Note")]
        public string Note { get; set; }

        [DisplayName("Creation Date Time")]
        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime? CreationDateTime { get; set; }

        [DisplayName("Last Modified DateTime")]
        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime? LastModifiedDateTime { get; set; }



    }
}
