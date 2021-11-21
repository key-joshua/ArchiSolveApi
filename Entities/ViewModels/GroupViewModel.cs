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
    public class GroupViewModel
    {
        [Key]
        [HiddenInput]
        public int GroupId { get; set; }

        [HiddenInput]
        public long? ObjectId { get; set; }

        [HiddenInput]
        public int? ParentId { get; set; }

        [HiddenInput]
        public int? SectionId { get; set; }

        [StringLength(30, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Code")]
        public string Code { get; set; }

        [Range(1, 20, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Type")]
        public byte? Type { get; set; }

        [Range(1, 100, ErrorMessageResourceName = "ValidRangeMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("ObjectType")]
        public byte? ObjectType { get; set; }

        [StringLength(3000, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [HiddenInput]
        public int? ListOrder { get; set; }

    }
}
