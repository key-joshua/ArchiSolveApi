using WebFramework.Api;
using Entities;

namespace ArchiSolveApi.Models
{
    public class SectionDto : BaseDto<SectionDto, Section, int>
    {
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Culture { get; set; }
    }

    public class SectionSelectDto : BaseDto<SectionSelectDto, Section, int>
    {
        public string Title { get; set; }
        public string Code { get; set; }
    }
}
