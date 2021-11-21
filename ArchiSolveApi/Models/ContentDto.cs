using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class ContentDto : BaseDto<ContentDto, Content, int>
    {
        public string Title { get; set; }
        public string UpperTitle { get; set; }
        public string BottomTitle { get; set; }
        public string ShortDescription { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public string Soustitre { get; set; }
        public string ShortTitle { get; set; }
        public string Source { get; set; }
        public string SourceURL { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }

    }

    public class ContentSelectDto : BaseDto<ContentSelectDto, Content, int>
    {
        public string Title { get; set; }
        public string UpperTitle { get; set; }
        public int ObjectType { get; set; }
        public string BottomTitle { get; set; }
        public string ShortDescription { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public string Soustitre { get; set; }
        public string ShortTitle { get; set; }
        public string Source { get; set; }
        public string SourceURL { get; set; }
        public ContentType Type { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublished { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public DateTime ExpirationDateTime { get; set; }
        public string Culture { get; set; }
        public virtual ICollection<Media> Medias { get; set; }
        public string TitleImage { get; set; }
        public string BodyImage { get; set; }
        public string SEOTitle { get; set; }
        public string SEODescription { get; set; }
    }


    public class ContentGridSelect : BaseDto<ContentGridSelect, Content, int>
    {
        public string Title { get; set; }
        public string UpperTitle { get; set; }
        public string BottomTitle { get; set; }
        public string ShortDescription { get; set; }
        public bool IsPublished { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PublishedDateTime { get; set; }
        public string SourceFileName { get; set; }
    }
}
