using Ecommerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Ecommerce_website.Pages
{
    public class ProductsModel : PageModel
    {
      
        public readonly AppDataContext _db;

        
        public ProductsModel(AppDataContext db)
        {
            _db = db;
        }
        [BindProperty]
        public string search { get; set; }
        public IEnumerable<Product> products { get; set; }
        
        public Cart Shopping_cart { get; set; }
        public string Email { get; set; }
        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public void OnGet()
        {
            products = _db.Products.ToList();
            

        }
   
        
        public IActionResult OnGetUpdate()
        {

            _db.Remove(_db.Products.Find(Id));
            _db.SaveChanges();
            return RedirectToPage("/Products");
        }
        public IActionResult OnGetDelete()
        {

            _db.Remove(_db.Products.Find(Id));
            _db.SaveChanges();
            return RedirectToPage("/Products");
        }
        public void OnPost() { 
            products = _db.Products.Where(o => o.Name.Contains(search));
        }
    }


}
