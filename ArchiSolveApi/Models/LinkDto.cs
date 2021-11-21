using Entities;
using WebFramework.Api;

namespace ArchiSolveApi.Models
{
    public class LinkDto : BaseDto<LinkDto, Link, int>
    {
        public string Title { get; set; }
        public string BottomTitle { get; set; }
        public string ShortDescription { get; set; }
        public ReservedTitle? ReservedTitle { get; set; }
        public LinkType? Type { get; set; }
        public string URL { get; set; }
        public bool? IsPublished { get; set; }
    }

    public class LinkSelectDto : BaseDto<LinkSelectDto, Link, int>
    {
        public string Title { get; set; }
        public string BottomTitle { get; set; }
        public string ShortDescription { get; set; }
        public ReservedTitle? ReservedTitle { get; set; }
        public LinkType? Type { get; set; }
        public string URL { get; set; }
    }
}
