using FLexElectronicsShop.Data;
using FLexElectronicsShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FLexElectronicsShop.Pages.DigitalProducts
{
    public class DeleteModel(FEShopContext fEShopContext) : PageModel
    {
        public Product? Product { get; set; }
        public async Task OnGetAsync(int id)
        {
            Product = await fEShopContext.Products.FirstAsync(product => product.Id == id);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {

            var digproduct = await fEShopContext.Products.FirstAsync(movie => movie.Id == id);
            fEShopContext.Products.Remove(digproduct);
            await fEShopContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
