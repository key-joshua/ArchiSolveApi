using WebFramework.Api;
using Entities;

namespace ArchiSolveApi.Models
{
    public class ZoneDto : BaseDto<ZoneDto, Zone, int>
    {
        public string Title { get; set; }
        public string Code { get; set; }
    }

    public class ZoneSelectDto : BaseDto<ZoneSelectDto, Zone, int>
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public string Culture { get; set; }
    }
}
