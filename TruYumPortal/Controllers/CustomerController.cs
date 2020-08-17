using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruYumPortal.Helper;
using TruYumPortal.Models;

namespace TruYumPortal.Controllers
{
    public class CustomerController : Controller
    {
        CustomerDataAccessLayer customerObject = new CustomerDataAccessLayer();
        AdminDataAccessLayer adminObject = new AdminDataAccessLayer();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetItems()
        {
            List<Items> lstItems = new List<Items>();
            lstItems = adminObject.GetAllItems().ToList();

            return View(lstItems);
        }
        [HttpGet]
        public IActionResult GetItem(int? id)
        {
            Items item = adminObject.GetItemById(id);
            return View(item);
        }
        [HttpGet]
        public IActionResult AddToCart(int? id)
        {
            Items item = customerObject.GetItemById(id);
            customerObject.AddToCart(item);
            return View(item);
        }
        [HttpGet]
        public IActionResult GetCartItems()
        {
            List<Cart> cartList = new List<Cart>();
            cartList = customerObject.GetCartItems().ToList();

            return View(cartList);
        }

        [HttpGet]
        public IActionResult DeleteCartItem(int? id)
        {
            Cart cart = customerObject.GetCartItemById(id);

            return View(cart);
        }

        [HttpPost, ActionName("DeleteCartItem")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCartItem(int id)
        {
            customerObject.DeleteCartItem(id);
            return RedirectToAction("GetCartItems");
        }
    }
}