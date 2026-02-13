using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProject.Services;

namespace MyProject_L00194748.Pages.Admin.Books
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<MyProject.Models.Models.BookDetails> Books;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            Books = _unitOfWork.BookDetailsRepo.GetAll(b => b.BookType);
            
        }
    }
}
