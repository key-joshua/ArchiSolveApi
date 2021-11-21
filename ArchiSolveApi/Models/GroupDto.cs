using Entities;
using System;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class GroupDto : BaseDto<GroupDto, Group, int>
    {
        public long ObjectId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public GroupType Type { get; set; }
        public ObjectType ObjectType { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int? ListOrder { get; set; }
        public int SectionRef { get; set; }
        public int? ParentId { get; set; }
    }

    public class GroupSelectDto : BaseDto<GroupSelectDto, Group, int>
    {

          public string Title { get; set; }
        public string Code { get; set; }
        public GroupType Type { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ObjectNote { get; set; }
        public string ObjectIsActive { get; set; }
        public string ObjectIsPublished { get; set; }
        public string ObjectPublishedDateTime { get; set; }
        public string ObjectExpirationDateTime { get; set; }
        public string ObjectCulture { get; set; }
        public string ParentGroupTitle { get; set; }
    }
}
