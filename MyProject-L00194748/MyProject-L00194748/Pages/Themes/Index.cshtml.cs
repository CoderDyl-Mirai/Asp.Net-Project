using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00194748.DataAccess;
using System;

namespace MyProject_L00194748.Pages.Themes
{
    public class IndexModel : PageModel
    {
        private readonly MangaShopDBContext _dbContext;
        public IEnumerable<Models.Themes> Themes;
        public IndexModel(MangaShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
            Themes = _dbContext.Themes;
        }
        public async Task<IActionResult> OnPost(Models.Themes theme)
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
