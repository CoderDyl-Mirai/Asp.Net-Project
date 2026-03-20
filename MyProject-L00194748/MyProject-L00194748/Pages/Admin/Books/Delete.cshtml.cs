using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.Services;

namespace MyProject_L00194748.Pages.Admin.Books
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public MyProject.Models.Models.BookDetails Book { get; set; }
        public IEnumerable<SelectListItem> ThemesList { get; set; }
        public IEnumerable<SelectListItem> BookTypeList { get; set; }

        public void OnGet(int id)
        {
            Book = _unitOfWork.BookDetailsRepo.Get(id);
            BookTypeList = _unitOfWork.BookTypesRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BookDetailsRepo.Delete(Book);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
