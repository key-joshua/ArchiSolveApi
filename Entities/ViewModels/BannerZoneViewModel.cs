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
    public class BannerZoneViewModel
    {
        [Key]
        [HiddenInput]
        public int ZoneId { get; set; }

        [Key]
        [HiddenInput]
        public int BannerId { get; set; }

        [DisplayName("Note")]
        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        public string Note { get; set; }

        [Range(1, 20, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Status")]
        public byte? Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        [DisplayName("Start Date Time")]
        public DateTime? StartDateTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        [DisplayName("End Date Time")]
        public DateTime? EndDateTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        [DisplayName("Published Date Time")]
        public DateTime? PublishedDateTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        [DisplayName("Creation Date Time")]
        public DateTime? CreationDateTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        [DisplayName("Last Modified Date Time")]
        public DateTime? LastModifiedDateTime { get; set; }

        [HiddenInput]
        public int? ListOrder { get; set; }

    }
}
