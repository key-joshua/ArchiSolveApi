using AutoMapper;
using Entities;
using System;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class CompanyDto : BaseDto<CompanyDto, Company, int>
    {
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Slagon { get; set; }
        public CompanyType? CompanyType { get; set; }
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
    }

    public class CompanySelectDto : BaseDto<CompanySelectDto, Company, int>
    {
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Slagon { get; set; }
        public CompanyType? CompanyType { get; set; }
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

        //public override void CustomMappings(IMappingExpression<Company, CompanySelectDto> mappingExpression)
        //{
        //    mappingExpression.ForMember(
        //            dest => dest.FullAddress,
        //            config => config.MapFrom(src => $"{src.Location.Title} {src.Location.Address}, {src.Location.SuburbName}, {src.Location.StateName}, {src.Location.PostalCode}"));
        //}
    }
}
