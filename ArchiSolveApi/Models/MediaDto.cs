using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class SendMediaDto : BaseDto<MediaDto, Media, int>
    {
        public string ReferenceId { get; set; }
        public string ObjectType { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string SourceFileName { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }
    public class MediaDto : BaseDto<MediaDto, Media, int>
    {
        public int ReferenceId { get; set; }
        public ObjectType? ObjectType { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string SourceFileName { get; set; }
        public string URL { get; set; }
        public MediaType MediaType { get; set; }
        public decimal? Price { get; set; }
        public bool? IsIcon { get; set; }
        public string Note { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }

    public class MediaSelectDto : BaseDto<MediaSelectDto, Media, int>
    {
        public int ReferenceId { get; set; }
        public ObjectType? ObjectType { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string SourceFileName { get; set; }
        public string URL { get; set; }
        public MediaType MediaType { get; set; }

    }
}
