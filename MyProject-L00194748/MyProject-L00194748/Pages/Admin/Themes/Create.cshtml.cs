using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.DataAccess.DataAccess;
using MyProject.Models.Models;
using System;

namespace MyProject_L00194748.Pages.Admin.Themes
{
    public class CreateModel : PageModel
    {
        private readonly MangaShopDBContext _dbContext;
        public CreateModel(MangaShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MyProject.Models.Models.Themes Theme { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(MyProject.Models.Models.Themes theme)
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
