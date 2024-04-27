using Ecommerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_website.Pages
{
    public class productthumbnailModel : PageModel
    {
        [BindProperty]
        public Product Products { get; set; }

        public readonly AppDataContext _db;

        public productthumbnailModel(AppDataContext db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public void OnGet()
        {
            Products = _db.Products.Find(Id);


        }
    }
}
