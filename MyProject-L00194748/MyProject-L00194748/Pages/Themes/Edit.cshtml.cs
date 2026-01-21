using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00194748.DataAccess;
using System;

namespace MyProject_L00194748.Pages.Themes
{
    public class EditModel : PageModel
    {
        private readonly MangaShopDBContext _dbContext;
        public EditModel(MangaShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Models.Themes Theme { get; set; }
        public void OnGet(int id)
        {
            Theme = _dbContext.Themes.Find(id);
        }
        public async Task<IActionResult> OnPost(Models.Themes theme)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(theme);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
