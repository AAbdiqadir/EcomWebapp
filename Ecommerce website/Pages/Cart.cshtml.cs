using Ecommerce_website.Helpers;
using Ecommerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_website.Pages
{
    public class CartModel : PageModel
    {
        public readonly AppDataContext _db;


        public CartModel(AppDataContext db)
        {
            _db = db;
        }
        public List<Cart> cart { get; set; }
        public decimal Total { get; set; }

        [BindProperty (SupportsGet = true)]

        public int id { get; set; }
        public void OnGet()
        {
            if (SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart") != null)
            {
                cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                Total = cart.Sum(i => i.Product.Price * i.Quantity);
            }
            else
            {
                cart = new List<Cart>();
                

               // SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", null);
            }

            
            

        }

        public IActionResult OnGetBuyNow(int id)
        {
            //var productModel = new ProductModel();
            cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<Cart>();
                cart.Add(new Cart
                {
                    Product = _db.Products.Find(id),
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Cart
                    {
                        Product = _db.Products.Find(id),
                        Quantity = 1
                    });
                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToPage("Cart");
        }

        public IActionResult OnGetDelete(int id)
        {
            cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("Cart");
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            if (cart != SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart"))
            {
                cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                for (var i = 0; i < cart.Count; i++)
                {
                    cart[i].Quantity = quantities[i];
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
                return RedirectToPage("Cart");
            
        }

        private int Exists(List<Cart> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
