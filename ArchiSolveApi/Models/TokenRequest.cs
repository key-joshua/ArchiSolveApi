using System.ComponentModel.DataAnnotations;

namespace MyApi.Models
{
    public class TokenRequest
    {
        //[Required]
        public string username { get; set; }
        public string password { get; set; }

    }
}
