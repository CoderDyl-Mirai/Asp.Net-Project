using MyProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Repository
{
    public interface IShoppingCartRepo : IRepository<ShoppingCart>
    {
        ShoppingCart IncrementItem(string userid, int id);
        int IncrementQty(ShoppingCart shoppingCart, int Qty);
    }
}
