using Ecommerce_website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Ecommerce_website.Pages
{



    public class FormModel : PageModel
    {
        
       
        [BindProperty]
        public Product Products { get; set; }

        public readonly AppDataContext _db;

        public FormModel(AppDataContext db)
        {
            _db = db;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public void OnGet()
        {
            Products = _db.Products.Find(Id);


        }
        public IActionResult OnPost()
        {

            _db.Products.Add(Products);
            _db.SaveChanges();
            return RedirectToPage("/Products");
        }
        
     
        public IActionResult OnPostUpdate()
        {
            _db.Products.Update(Products);
            _db.SaveChanges();
            return RedirectToPage("/Form");
        }
    }
}
