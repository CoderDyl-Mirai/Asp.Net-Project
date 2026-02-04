using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.DataAccess.DataAccess;
using MyProject.Models.Models;
using MyProject.Services;
using System;

namespace MyProject_L00194748.Pages.Admin.Themes
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<MyProject.Models.Models.Themes> Themes;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            Themes = _unitOfWork.ThemesRepo.GetAll();
        }
        public IActionResult OnPost(MyProject.Models.Models.Themes theme)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ThemesRepo.Delete(theme);
                _unitOfWork.Save();

            }
            return RedirectToPage("Index");
        }
    }
}
