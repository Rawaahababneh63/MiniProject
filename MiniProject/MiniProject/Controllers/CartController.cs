using MiniProject.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace MiniProject.Controllers
{
    public class CartController : Controller
    {
        private EcommerceEntities db = new EcommerceEntities();
        public ActionResult Cart(int? id)
        {
            // افترض أنك تحصل على UserID من الجلسة أو من مصدر آخر
            //int userId = ...;  وضع الكود المناسب للحصول على UserID للمستخدم الحالي

            // الحصول على السلة والعناصر المرتبطة بها
            var cartItems = db.Carts
                              .Where(c => c.User_ID == id)
                              .SelectMany(c => c.Cart_Item)
                              .Include(ci => ci.Product) // جلب تفاصيل المنتج
                              .ToList();

            return View(cartItems);
        }
        public ActionResult Create(int id, int userID)
        {
            int userId = userID;

            var cart = db.Carts.SingleOrDefault(c => c.User_ID == userId);

            if (cart == null)
            {
                cart = new Cart { User_ID = userId };
                db.Carts.Add(cart);
                db.SaveChanges();
            }

            var existingCartItem = db.Cart_Item.SingleOrDefault(ci => ci.Cart_ID == cart.ID && ci.Product_ID == id);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                var cartItem = new Cart_Item
                {
                    Cart_ID = cart.ID,
                    Product_ID = id,
                    Quantity = 1
                };
                db.Cart_Item.Add(cartItem);
            }

            db.SaveChanges();

            return RedirectToAction("Cart", new { id = userId });
        }

        public ActionResult UpdateQuantity(int id, int quantity)
        {
            var cartItem = db.Cart_Item.Find(id);

            if (cartItem != null && quantity > 0)
            {
                cartItem.Quantity = quantity;
                db.SaveChanges();
            }
            else if (cartItem != null && quantity == 0)
            {
                db.Cart_Item.Remove(cartItem);
                db.SaveChanges();
            }

            return RedirectToAction("Cart", new { id = Session["ID"] });
        }


        public ActionResult Remove(int id)
        {
            var cartItem = db.Cart_Item.Find(id);

            if (cartItem != null)
            {
                db.Cart_Item.Remove(cartItem);
                db.SaveChanges();
            }

            return RedirectToAction("Cart", new { id = Session["ID"] /*cartItem.Cart.UserID*/ });
        }
    }
}