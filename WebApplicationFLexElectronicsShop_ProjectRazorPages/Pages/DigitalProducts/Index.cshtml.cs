using FLexElectronicsShop.Data;
using FLexElectronicsShop.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FLexElectronicsShop.Pages.DigitalProducts
{
    public class IndexModel(FEShopContext eShopContext) : PageModel
    {
        public IEnumerable<Product> Products {  get; set; } = eShopContext.Products;
        public void OnGet()
        {
        }
    }
}
