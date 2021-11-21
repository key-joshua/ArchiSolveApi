using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class sd : BaseDto<sd, Page, int>
    {
        public string Code { get; set; }
        public string UpperTitle { get; set; }
        public string Title { get; set; }
        public string BottomTitle { get; set; }
        public string Note { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public string Culture { get; set; }
    }

    public class PageSelectDto : BaseDto<PageSelectDto, Page, int>
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string UpperTitle { get; set; }
        public string BottomTitle { get; set; }
        public string Note { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ParentPageTitle { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public IQueryable<Media> Medias { get; set; }
        public IQueryable<Link> Links { get; set; }
    }
}
