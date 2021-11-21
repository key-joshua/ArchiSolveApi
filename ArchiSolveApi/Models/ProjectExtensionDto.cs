using Entities;
using System;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class ProjectExtensionDto : BaseDto<ProjectExtensionDto, ProjectExtension, int>
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Slagon { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public int? ProjectRef { get; set; }
    }

    public class ProjectExtensionSelectDto : BaseDto<ProjectExtensionSelectDto, ProjectExtension, int>
    {
        public long ObjectId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Slagon { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public int? ListOrder { get; set; }
        public int? ProjectRef { get; set; }
        public string ProjectTitle { get; set; }
        public string ObjectNote { get; set; }
        public string ObjectIsActive { get; set; }
        public string ObjectIsPublished { get; set; }
        public string ObjectPublishedDateTime { get; set; }
        public string ObjectExpirationDateTime { get; set; }
        public string ObjectCulture { get; set; }
    }
}
