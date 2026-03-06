using MyProject.DataAccess.DataAccess;
using MyProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Repository
{
    public class ShoppingCartRepo : Repository<ShoppingCart>, IShoppingCartRepo
    {
        private readonly MangaShopDBContext _dbContext;
        public ShoppingCartRepo(MangaShopDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public ShoppingCart IncrementItem(string userid, int id)
        {
            var ShoppingCartItem = _dbContext.ShoppingCart.Where(p => p.BookId == id && p.ApplicationUserId == userid).FirstOrDefault();
            return ShoppingCartItem;
        }
        public int IncrementQty(ShoppingCart shoppingCart, int qty)
        {
            shoppingCart.Quantity += qty;
            _dbContext.SaveChanges();
            return shoppingCart.Quantity;
        }
    }

}