using Microsoft.AspNetCore.Mvc;
using Eccomerce_Full_Stack.Models;
using Eccomerce_Full_Stack.helpers;

namespace Eccomerce_Full_Stack.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? [];
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(Guid productId, string productName, double price, string image)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? [];

            var cartItem = cart.Find(c => c.ProductId == productId);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = 1,
                    Image = image
                });
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(Guid productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? [];
            var cartItem = cart.Find(c => c.ProductId == productId);

            if (cartItem != null)
            {
                cart.Remove(cartItem);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }
    }
}