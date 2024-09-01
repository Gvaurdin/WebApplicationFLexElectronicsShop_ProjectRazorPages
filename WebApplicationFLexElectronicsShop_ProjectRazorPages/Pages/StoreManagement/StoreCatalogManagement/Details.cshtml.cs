using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FLexElectronicsShop.Data;
using FLexElectronicsShop.Model;

namespace FLexElectronicsShop.Pages.StoreManagement.StoreCatalogManagement
{
    public class DetailsModel : PageModel
    {
        private readonly FLexElectronicsShop.Data.FEShopContext _context;

        public DetailsModel(FLexElectronicsShop.Data.FEShopContext context)
        {
            _context = context;
        }

        public CatalogItem CatalogItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogitem = await _context.CatalogItems.FirstOrDefaultAsync(m => m.Id == id);
            if (catalogitem == null)
            {
                return NotFound();
            }
            else
            {
                CatalogItem = catalogitem;
            }
            return Page();
        }
    }
}
