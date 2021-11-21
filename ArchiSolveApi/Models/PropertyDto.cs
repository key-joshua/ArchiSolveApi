using WebFramework.Api;
using Entities;

namespace ArchiSolveApi.Models
{
    public class PropertyDto : BaseDto<PropertyDto, Property, int>
    {
        public string Title { get; set; }
        public PropertyType Type { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
    }

    public class PropertySelectDto : BaseDto<PropertySelectDto, Property, int>
    {
        public string Title { get; set; }
        public PropertyType Type { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public int? ListOrder { get; set; }
        public string Culture { get; set; }
    }
}
