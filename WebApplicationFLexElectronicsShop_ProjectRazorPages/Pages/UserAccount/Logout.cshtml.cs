using FLexElectronicsShop.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FLexElectronicsShop.Pages.UserAccount
{
    public class LogoutModel(SignInManager<User> signInManager) : PageModel
    {
        public async Task<IActionResult> OnPostAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("../Index");
        }
    }
}
