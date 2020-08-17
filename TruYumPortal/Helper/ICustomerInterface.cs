using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruYumPortal.Models;

namespace TruYumPortal.Helper
{
    interface ICustomerInterface
    {
        
        public void AddToCart(Items item);
        public List<Cart> GetCartItems();
        public void DeleteCartItem(int id);
        public Cart GetCartItemById(int? cartId);
    }
}
