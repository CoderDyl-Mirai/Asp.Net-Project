using System.ComponentModel.DataAnnotations;

namespace RP1Tut_L00184748_atu.ie.Pages.PageViewModels
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)] public string Password { get; set; } = string.Empty;
        [Required]
        public bool RememberMe { get; set; }
    }
}
