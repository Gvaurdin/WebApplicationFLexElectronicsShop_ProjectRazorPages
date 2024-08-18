using FLexElectronicsShop.Data;
using FLexElectronicsShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FLexElectronicsShop.Pages.DigitalProducts
{
    public class DetailsModel(FEShopContext fEShopContext) : PageModel
    {
        public Product Product { get; set; }
        public async Task OnGetAsync(int id)
        {
            Product = await fEShopContext.Products.FirstAsync(p => p.Id == id);
        }
    }
}
