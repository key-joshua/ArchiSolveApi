using Entities.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArchiSolve.Models.ViewModels
{
    public class CommentViewModel
    {
        [Key]
        [HiddenInput]
        public int CommentId { get; set; }

        [Range(1, 20, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Role")]
        public byte? Role { get; set; }

        [DisplayName("No Count")]
        public int? NoCount { get; set; }

        [DisplayName("Yes Count")]
        public int? YesCount { get; set; }

        [HiddenInput]
        public long? UserObjectId { get; set; }

        [HiddenInput]
        public long? ProfileObjectId { get; set; }

        [HiddenInput]
        public long? ParentId { get; set; }

        [StringLength(400, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Subject")]
        public string Subject { get; set; }

        [Required]
        [StringLength(2000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Description")]
        public string Description { get; set; }


        [RegularExpression(@"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\.|$)){4}\b", ErrorMessageResourceName = "IPIsNotValid", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [StringLength(50, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Sender IP")]
        [HiddenInput]
        public string SenderIP { get; set; }

        [Url(ErrorMessage ="URL Is Not Valid")]
        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Sender URL")]
        public string SenderUrl { get; set; }

        [HiddenInput]
        public int? RoomId { get; set; }

        [StringLength(400, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Room Name")]
        public string RoomName { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Sender Full Name")]
        public string SenderFullName { get; set; }

        [EmailAddress]
        [StringLength(300, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Sender Email")]
        public string SenderEmail { get; set; }

        [StringLength(500, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Sender Email")]
        public string Note { get; set; }

        
        [DisplayName("Is Published")]
        public bool IsPublished { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        [DisplayName("Published Date Time")]
        public DateTime? PublishedDateTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        [DisplayName("Creation Date Time")]
        public DateTime? CreationDateTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        [DisplayName("Expiration Date Time")]
        public DateTime? ExpirationDateTime { get; set; }
    }
}
