using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.DataAccess.DataAccess;
using MyProject.Models.Models;
using MyProject.Services;
using System;

namespace MyProject_L00194748.Pages.Admin.Types
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<MyProject.Models.Models.BookTypes> Types;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            Types = _unitOfWork.BookTypesRepo.GetAll();
        }
        public IActionResult OnPost(MyProject.Models.Models.BookTypes type)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BookTypesRepo.Delete(type);
                _unitOfWork.Save();

            }
            return RedirectToPage("Index");
        }
    }
}
