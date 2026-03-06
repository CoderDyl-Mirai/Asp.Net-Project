using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.Models.Models;
using MyProject.Services;
using System.Security.Claims;

namespace MyProject_L00194748.Pages.Customer.Home
{
    [Authorize(Roles = "Customer,Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public ShoppingCart ShoppingCart { get; set; }
        [BindProperty]
        public BookDetails Book { get; set; }
        public void OnGet(int id)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCart = new()
            {
                //Product = _unitOfWork.ProductRepo.Get(id);
                ApplicationUserId = claim.Value,
                Quantity = 1,
                Book = _unitOfWork.BookDetailsRepo.GetBookType(id),
                BookId = id
            };
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ShoppingCart shopppingCartFromDb = _unitOfWork.ShoppingCartRepo.IncrementItem(ShoppingCart.ApplicationUserId, ShoppingCart.BookId);
                if (shopppingCartFromDb == null)
                {
                    _unitOfWork.ShoppingCartRepo.Add(ShoppingCart);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.ShoppingCartRepo.IncrementQty(shopppingCartFromDb, ShoppingCart.Quantity);
                }
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}