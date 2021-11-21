using System.ComponentModel.DataAnnotations;
using Common.Resources;

namespace Common
{
    public enum ApiResultStatusCode
    {
        [Display(Name = "ApiResultSuccess", ResourceType = typeof(DisplayResources))]
        Success = 0,

        [Display(Name = "ApiResultServerError", ResourceType = typeof(DisplayResources))]
        ServerError = 1,

        [Display(Name = "ApiResultBadRequest", ResourceType = typeof(DisplayResources))]
        BadRequest = 2,

        [Display(Name = "ApiResultNotFound", ResourceType = typeof(DisplayResources))]
        NotFound = 3,

        [Display(Name = "ApiResultListEmpty", ResourceType = typeof(DisplayResources))]
        ListEmpty = 4,

        [Display(Name = "ApiResultLogicError", ResourceType = typeof(DisplayResources))]
        LogicError = 5,

        [Display(Name = "ApiResultUnAuthorized", ResourceType = typeof(DisplayResources))]
        UnAuthorized = 6
    }
}
