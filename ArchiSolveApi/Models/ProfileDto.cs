using AutoMapper;
using Entities;
using System;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class ProfileDto : BaseDto<ProfileDto, Entities.Profile, int>
    {
        public string Title { get; set; }
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public EducationDegree? EducationDegree { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }
        public string HomeCall { get; set; }
        public string WorkCall { get; set; }
        public string Cellphone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public ProfileType? ProfileType { get; set; }
        public string AcademicRank { get; set; }
        public string CertificatePlace { get; set; }
        public string Skills { get; set; }
        public string ShortDescription { get; set; }
        public string Department { get; set; }
        public string Biography { get; set; }
        public string Favorites { get; set; }
        public bool IsVisible { get; set; }
        public string NationalCode { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public int? UserRef { get; set; }
        public int? CompanyRef { get; set; }
        public int? LocationRef { get; set; }
    }

    public class ProfileSelectDto : BaseDto<ProfileSelectDto, Entities.Profile, int>
    {
        public string Title { get; set; }
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public EducationDegree? EducationDegree { get; set; }
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public string WorkAddress { get; set; }
        public string HomeCall { get; set; }
        public string WorkCall { get; set; }
        public string Cellphone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public ProfileType? ProfileType { get; set; }
        public string AcademicRank { get; set; }
        public string CertificatePlace { get; set; }
        public string Skills { get; set; }
        public string ShortDescription { get; set; }
        public string Department { get; set; }
        public string Biography { get; set; }
        public string Favorites { get; set; }
        public string NationalCode { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public string UserUserName { get; set; }

        public string CompanyRef { get; set; }

        public string CompanyCompanyName { get; set; }

        public string FullAddress { get; set; }
        public string ObjectNote { get; set; }
        public string ObjectIsActive { get; set; }
        public string ObjectIsPublished { get; set; }
        public string ObjectPublishedDateTime { get; set; }
        public string ObjectExpirationDateTime { get; set; }
        public string ObjectCulture { get; set; }


        //public override void CustomMappings(IMappingExpression<Entities.Profile, ProfileSelectDto> mappingExpression)
        //{
        //    mappingExpression.ForMember(
        //            dest => dest.FullAddress,
        //            config => config.MapFrom(src => $"{src.Location.Title} {src.Location.Address}, {src.Location.SuburbName}, {src.Location.StateName}, {src.Location.PostalCode}"));
        //}
    }
}
