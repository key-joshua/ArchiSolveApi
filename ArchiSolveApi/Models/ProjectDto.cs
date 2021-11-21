using AutoMapper;
using Entities;
using System;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class ProjectDto : BaseDto<ProjectDto, Project, int>
    {
        //public long Id { get; set; }
        public string ProjectName { get; set; }
        public string Title { get; set; }
        public string Slagon { get; set; }
        public ProjectType? ProjectType { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Cellphone { get; set; }
        public string Address { get; set; }
        public DateTime? StablishDateTime { get; set; }
        public DateTime? StartCooperationDateTime { get; set; }
        public DateTime? EndCooperationDateTime { get; set; }
        public int LocationRef { get; set; }

        public ObjectType ObjectType { get; set; } = ObjectType.Project;
        public string ObjectNote { get; set; }
        public bool? ObjectIsActive { get; set; }
        public bool? ObjectIsPublished { get; set; }
        public DateTime? ObjectPublishedDateTime { get; set; }
        public string ObjectCulture { get; set; } = "en-Us";
    }

    public class ProjectSelectDto : BaseDto<ProjectSelectDto, Project, int>
    {
        public string ProjectName { get; set; }
        public string Title { get; set; }
        public string Slagon { get; set; }
        public ProjectType? ProjectType { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Cellphone { get; set; }
        public string Address { get; set; }
        public DateTime? StablishDateTime { get; set; }
        public DateTime? StartCooperationDateTime { get; set; }
        public DateTime? EndCooperationDateTime { get; set; }
        public string FullAddress { get; set; }

        //public override void CustomMappings(IMappingExpression<Project, ProjectSelectDto> mappingExpression)
        //{
        //    mappingExpression.ForMember(
        //            dest => dest.FullAddress,
        //            config => config.MapFrom(src => $"{src.Location.Title} {src.Location.Address}, {src.Location.SuburbName}, {src.Location.StateName}, {src.Location.PostalCode}"));
        //}
    }
}
