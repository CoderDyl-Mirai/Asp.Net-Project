using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1Tut_L00184748_atu.ie.Pages.PageViewModels;

namespace RP1Tut_L00184748_atu.ie.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        [BindProperty]
        public Login Login { get; set; }
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var Result = await _signInManager.PasswordSignInAsync(Login.EmailAddress, Login.Password, Login.RememberMe, false);
                if(Result.Succeeded)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is incorrect");
                    return Page();
                }
            }
            return RedirectToPage("Index");
        }
    }
}
