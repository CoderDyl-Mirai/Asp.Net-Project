using System.ComponentModel.DataAnnotations;

namespace RP1Tut_L00184748_atu.ie.Pages.PageViewModels
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)] public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
