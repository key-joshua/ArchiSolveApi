using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class BannerDto : BaseDto<BannerDto, Banner, int>
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string SourceFileName { get; set; }
        public bool? IsPublished { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        [IgnoreMap]
        public List<string> ZoneTitles { get; set; }
    }

    public class BannerSelectDto : BaseDto<BannerSelectDto, Banner, int>
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string SourceFileName { get; set; }
        public string Url { get; set; }
        public BannerType? Type { get; set; }
        public string Note { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }

        [IgnoreMap]
        public List<int> ZoneIds { get; set; }
    }
}
