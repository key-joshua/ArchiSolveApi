using Entities;
using System;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class DocumentDto : BaseDto<DocumentDto, Document, int>
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Institution { get; set; }
        public string IssueNumber { get; set; }
        public DocumentType? Type { get; set; }
        public DocumentStatus? Status { get; set; }
        public DateTime? ValidityStartDateTime { get; set; }
        public DateTime? ValidityExpirtationDateTime { get; set; }

    }

    public class DocumentSelectDto : BaseDto<DocumentSelectDto, Document, int>
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Institution { get; set; }
        public string IssueNumber { get; set; }
        public DocumentType? Type { get; set; }
        public DocumentStatus? Status { get; set; }
        public DateTime? ValidityStartDateTime { get; set; }
        public DateTime? ValidityExpirtationDateTime { get; set; }
        public string ObjectNote { get; set; }
        public string ObjectIsActive { get; set; }
        public string ObjectIsPublished { get; set; }
        public string ObjectPublishedDateTime { get; set; }
        public string ObjectExpirationDateTime { get; set; }
        public string ObjectCulture { get; set; }
    }
}
