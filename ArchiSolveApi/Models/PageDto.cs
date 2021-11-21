using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class PageDto : BaseDto<PageDto, Page, int>
    {
        public string Code { get; set; }
        public string UpperTitle { get; set; }
        public string Title { get; set; }
        public string BottomTitle { get; set; }
        public string Note { get; set; }
        public string ShortDescription { get; set; }
        public bool? IsPublished { get; set; }
        public string Description { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
    }

    public class PageSelectDto : BaseDto<PageSelectDto, Page, int>
    {
        public string Code { get; set; }
        public string UpperTitle { get; set; }
        public string Title { get; set; }
        public string BottomTitle { get; set; }
        public string Note { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool? IsPublished { get; set; }
        public int? ParentId { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
    }
}
