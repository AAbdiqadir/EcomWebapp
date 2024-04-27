using Ecommerce_website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_website.Pages
{
    public class ManageUsersModel : PageModel
    {
        private readonly UserManager<AppUser> UserManager1;

        public List  <AppUser> Users { get; set; }
        public ManageUsersModel(UserManager<AppUser> UserManager) {
            UserManager1 = UserManager;
        }
        public void OnGet() {
            Users = UserManager1.Users.ToList();
        }
        [BindProperty (SupportsGet = true)]
        public string Id { get; set; }   
        public async Task<IActionResult> OnGetDeleteAsync() {
            var users = await UserManager1.FindByIdAsync(Id);
            var Result = await UserManager1.DeleteAsync(users);
            return RedirectToPage("/ManageUsers");
        }
        
        }
    }

