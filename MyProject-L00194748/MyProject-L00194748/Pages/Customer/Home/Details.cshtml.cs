using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.Models.Models;
using MyProject.Services;

namespace MyProject_L00194748.Pages.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public BookDetails Book { get; set; }
        public void OnGet(int id)
        {
            Book = _unitOfWork.BookDetailsRepo.Get(id);
        }
    }
}
