using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.DataAccess.DataAccess;
using MyProject.Models.Models;
using System;

namespace MyProject_L00194748.Pages.Admin.Themes
{
    public class IndexModel : PageModel
    {
        private readonly MangaShopDBContext _dbContext;
        public IEnumerable<MyProject.Models.Models.Themes> Themes;
        public IndexModel(MangaShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
            Themes = _dbContext.Themes;
        }
        public async Task<IActionResult> OnPost(MyProject.Models.Models.Themes theme)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Themes.Remove(theme);
                await _dbContext.SaveChangesAsync();

            }
            return RedirectToPage("Index");
        }
    }
}
