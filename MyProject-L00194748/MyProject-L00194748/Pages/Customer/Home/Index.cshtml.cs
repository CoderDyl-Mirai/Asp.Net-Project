using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.Models.Models;
using MyProject.Services;

namespace MyProject_L00194748.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<BookDetails> listOfBooks { get; set; }
        public IEnumerable<Themes> listOfThemes { get; set; }
        public IEnumerable<BookTypes> listOfTypes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public void OnGet()
        {
            listOfBooks = _unitOfWork.BookDetailsRepo.GetAll();
            listOfThemes = _unitOfWork.ThemesRepo.GetAll();
            listOfTypes = _unitOfWork.BookTypesRepo.GetAll();

            if (!string.IsNullOrEmpty(SearchString))
            {
                listOfBooks = listOfBooks.Where(p => p.Title.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
            }

        }
    }
}
