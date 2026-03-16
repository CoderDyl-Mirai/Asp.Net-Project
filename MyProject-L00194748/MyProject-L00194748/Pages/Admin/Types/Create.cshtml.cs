using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.DataAccess.DataAccess;
using MyProject.Models.Models;
using MyProject.Services;
using System;

namespace MyProject_L00194748.Pages.Admin.Types
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public MyProject.Models.Models.BookTypes Types { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(MyProject.Models.Models.BookTypes types)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BookTypesRepo.Add(types);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
