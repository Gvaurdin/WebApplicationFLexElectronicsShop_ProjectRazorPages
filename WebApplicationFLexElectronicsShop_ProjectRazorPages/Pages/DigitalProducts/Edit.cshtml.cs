using FLexElectronicsShop.Data;
using FLexElectronicsShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FLexElectronicsShop.Pages.DigitalProducts
{
    public class EditModel(FEShopContext fEShopContext) : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        public async Task OnGetAsync(int id)
        {
            Product = await fEShopContext.Products.FirstAsync(p => p.Id == id);

        }

        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var updateProduct = await fEShopContext.Products.FirstAsync(p => p.Id == id);
            updateProduct!.Name = Product!.Name;
            updateProduct.URL = Product!.URL;
            updateProduct.Description = Product!.Description;
            updateProduct.Price = Product!.Price;
            await fEShopContext.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
