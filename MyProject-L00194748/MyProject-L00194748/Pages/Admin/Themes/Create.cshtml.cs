using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.DataAccess.DataAccess;
using MyProject.Models.Models;
using MyProject.Services;
using System;

namespace MyProject_L00194748.Pages.Admin.Themes
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public MyProject.Models.Models.Themes Theme { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(MyProject.Models.Models.Themes theme)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ThemesRepo.Add(theme);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
