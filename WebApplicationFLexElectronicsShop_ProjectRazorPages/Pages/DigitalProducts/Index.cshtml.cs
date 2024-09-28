using FLexElectronicsShop.Data;
using FLexElectronicsShop.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FLexElectronicsShop.Pages.DigitalProducts
{
    public class IndexModel(FEShopContext eShopContext) : PageModel
    {
        public IList<Product> Products { get; set; }
        public SelectList Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? SelectedCategoryId { get; set; }

        public async Task OnGetAsync()
        {
            Categories = new SelectList(await eShopContext.Categories.ToListAsync(), "Id", "Name");

            IQueryable<Product> productsQuery = eShopContext.Products.Include(p => p.Category);

            if (SelectedCategoryId.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Category.Id == SelectedCategoryId.Value);
            }

            Products = await productsQuery.ToListAsync();
        }
    }
}
