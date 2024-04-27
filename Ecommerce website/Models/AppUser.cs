using Microsoft.AspNetCore.Identity;

namespace Ecommerce_website.Models
{
    public class AppUser:IdentityUser
    {
       public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
