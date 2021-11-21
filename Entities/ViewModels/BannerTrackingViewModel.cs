using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ArchiSolve.Models.ViewModels
{
    public class BannerTrackingViewModel
    {
        [Key]
        [HiddenInput]
        public int BannerTrackingId { get; set; }

        public int ViewCount { get; set; }

        [Range(1, 20)]
        public byte? Type { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public DateTime? CreationDateTime { get; set; }


    }
}
