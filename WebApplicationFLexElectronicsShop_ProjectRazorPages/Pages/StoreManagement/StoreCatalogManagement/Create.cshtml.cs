using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FLexElectronicsShop.Data;
using FLexElectronicsShop.Model;
using Microsoft.EntityFrameworkCore;

namespace FLexElectronicsShop.Pages.StoreManagement.StoreCatalogManagement
{
    public class CreateModel : PageModel
    {
        private readonly FLexElectronicsShop.Data.FEShopContext _context;

        public CreateModel(FLexElectronicsShop.Data.FEShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description");
        ViewData["PromotionId"] = new SelectList(_context.Promotions, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CatalogItem CatalogItem { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            CatalogItem.Promotion = await _context.Promotions.FirstAsync(p => p.Id == CatalogItem.PromotionId);
            CatalogItem.ApplyDiscount(CatalogItem.Promotion,CatalogItem.DiscountedPrice,CatalogItem.Price);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.CatalogItems.Add(CatalogItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
