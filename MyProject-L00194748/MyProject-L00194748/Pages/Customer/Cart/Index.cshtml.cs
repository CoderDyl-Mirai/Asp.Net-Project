using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProject.Models.Models;
using MyProject.Services;
using System.Security.Claims;

namespace MyProject_L00194748.Pages.Customer.Cart
{
    public class IndexModel : PageModel
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        public double CartTotal;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null) 
            {
                ShoppingCartList = _unitOfWork.ShoppingCartRepo.GetShoppingCartsBooks(claim.Value);
                foreach(var item in ShoppingCartList)
                {
                    CartTotal += (double)(item.Quantity * item.Book.Price);
                }

            }
        }
        public IActionResult OnPostPlus(int CartId)
        {
            var cart = _unitOfWork.ShoppingCartRepo.Get(CartId);
            _unitOfWork.ShoppingCartRepo.IncrementQty(cart, 1);
            return RedirectToPage("/Customer/Cart/Index");
        }
        public IActionResult OnPostMinus(int CartId)
        {
            var cart = _unitOfWork.ShoppingCartRepo.Get(CartId);
            if(cart.Quantity == 1)
            {
                _unitOfWork.ShoppingCartRepo.Delete(cart);
                _unitOfWork.Save();
            }
            else
            {
                _unitOfWork.ShoppingCartRepo.DecrementQty(cart, 1);
            }
             return RedirectToPage("/Customer/Cart/Index");
        }
        public IActionResult OnPostRemove(int CartId)
        {
            var cart = _unitOfWork.ShoppingCartRepo.Get(CartId);
            _unitOfWork.ShoppingCartRepo.Delete(cart);
            _unitOfWork.Save();
            return RedirectToPage("/Customer/Cart/Index");
        }

    }
}
