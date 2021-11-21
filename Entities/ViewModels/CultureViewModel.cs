using Entities.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArchiSolve.Models.ViewModels
{
    public class CultureViewModel
    {
        [Key]
        public int CultureId { get; set; }

        [StringLength(10, ErrorMessageResourceName = "StringLengthMessage", ErrorMessageResourceType = typeof(DataAnnotationsResources))]
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }
    }
}
