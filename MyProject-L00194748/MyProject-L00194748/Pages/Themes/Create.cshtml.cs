using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject_L00194748.DataAccess;
using System;

namespace MyProject_L00194748.Pages.Themes
{
    public class CreateModel : PageModel
    {
        private readonly MangaShopDBContext _dbContext;
        public CreateModel(MangaShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Models.Themes Theme { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(Models.Themes theme)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.AddAsync(theme);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage("Index");
        }
    }
}
