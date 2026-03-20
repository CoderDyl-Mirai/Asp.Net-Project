using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.DataAccess.DataAccess;
using MyProject.Models.Models;
using MyProject.Services;
using System;

namespace MyProject_L00194748.Pages.Admin.Types
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public MyProject.Models.Models.BookTypes Types { get; set; }
        public void OnGet(int id)
        {
            Types = _unitOfWork.BookTypesRepo.Get(id);
        }
        public IActionResult OnPost(MyProject.Models.Models.BookTypes Type)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BookTypesRepo.Update(Type);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
