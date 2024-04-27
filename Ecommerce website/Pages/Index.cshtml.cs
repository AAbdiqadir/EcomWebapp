using Ecommerce_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce_website.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Product> products { get; set; }

      
      
        public void OnGet()
        {
            products = new List<Product>{
new Product()
{
Id = 01,
Name = "Barcelona traning kit",

ProductImage = "image/barca.jpeg",
Price= 50
},
new Product()
{
Id = 02,
Name = "Down jacket",

ProductImage = "image/down.jpeg",
Price= 50
},
new Product()
{
Id = 02,
Name = "Padded lightweight gilet",

ProductImage = "image/halfies.jpeg",
Price= 50
}
,
new Product()
{
Id = 02,
Name = "Blue jens",

ProductImage = "image/jeans.jpeg",
Price= 50
}

};
        }
        }
    }
