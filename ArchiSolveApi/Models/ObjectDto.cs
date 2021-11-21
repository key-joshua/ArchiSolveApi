using Entities;
using System;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class CompanyObjectDto  : BaseDto<CompanyObjectDto, Entities.Object, long >
    {
        public ObjectType Type { get; set; } = ObjectType.Comapny;
        public int CompanyRef { get; set; }
        public SharedProperties SharedProperties { get; set; }
    }

    public class ProejctObjectDto : BaseDto<ProejctObjectDto, Entities.Object, long>
    {
        public ObjectType Type { get; set; } = ObjectType.Project;
        public int ProjectRef { get; set; }
        public SharedProperties SharedProperties { get; set; }
    }

    public class ContentObjectDto : BaseDto<ContentObjectDto, Entities.Object, long>
    {
        public ObjectType Type { get; set; } = ObjectType.Content;
        public int ContentRef { get; set; }
        public SharedProperties SharedProperties { get; set; }
    }
    public class GroupObjectDto : BaseDto<GroupObjectDto, Entities.Object, long>
    {
        public ObjectType Type { get; set; } = ObjectType.Group;
        public int GroupRef { get; set; }
        public SharedProperties SharedProperties { get; set; }
    }
    public class DocumentObjectDto : BaseDto<DocumentObjectDto, Entities.Object, long>
    {
        public ObjectType Type { get; set; } = ObjectType.Document;
        public int DocumentRef { get; set; }
        public SharedProperties SharedProperties { get; set; }

    }
  
    public class ProfileObjectDto : BaseDto<ProfileObjectDto, Entities.Object, long>
    {
        public ObjectType Type { get; set; } = ObjectType.Profile;
        public int ProfileRef { get; set; }
        public SharedProperties SharedProperties { get; set; }

    }
    public class PageObjectDto : BaseDto<PageObjectDto, Entities.Object, long>
    {
        public ObjectType Type { get; set; } = ObjectType.Page;
        public int PageRef { get; set; }
        public SharedProperties SharedProperties { get; set; }
    }

    public class ProjectExtensionObjectDto : BaseDto<ProjectExtensionObjectDto, Entities.Object, long > 
    {

        public ObjectType Type { get; set; } = ObjectType.ProjectExtension;
        public int ProjectExtensionRef { get; set; }
        public SharedProperties SharedProperties { get; set; }
        
    }

    public class SharedProperties
    {
        public string Note { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public DateTime? PublishedDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public string Culture { get; set; }
    }
}
