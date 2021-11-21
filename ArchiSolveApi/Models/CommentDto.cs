using Entities;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class CommentDto : BaseDto<CommentDto, Comment, int>
    {
        public RoleType? Role { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderIP { get; set; }
        public string SenderUrl { get; set; }
        public string SenderTitle { get; set; }
        public string SourceFileName { get; set; }
        public string SenderFullName { get; set; }
        public string SenderEmail { get; set; }
        public string Note { get; set; }
        public bool? IsPublished { get; set; }
        public int ProfileRef { get; set; }
        public int? ParentId { get; set; }
    }

    public class CommentSelectDto : BaseDto<CommentSelectDto, Comment, int>
    {
        //public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderFullName { get; set; }
        public string SenderTitle { get; set; }
        public string SourceFileName { get; set; }
        public bool? IsPublished { get; set; }

        //public string SenderEmail { get; set; }
        //public string ProfileFirstName { get; set; }
        //public string ProfileLastName { get; set; }
    }
}
