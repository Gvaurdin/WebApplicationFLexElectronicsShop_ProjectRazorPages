using FLexElectronicsShop.Data;
using FLexElectronicsShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FLexElectronicsShop.Pages.DigitalProducts
{
    public class AddModel(FEShopContext fEShopContext) : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public Product product { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (product is null || !ModelState.IsValid)
            {
                return Page();
            }

            await fEShopContext.Products.AddAsync(product);
            await fEShopContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
