using System.ComponentModel.DataAnnotations;

namespace MyProject_L00194748.Pages.PageViewModels
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
