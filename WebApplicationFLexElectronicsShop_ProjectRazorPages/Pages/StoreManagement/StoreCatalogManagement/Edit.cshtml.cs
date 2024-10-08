﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FLexElectronicsShop.Data;
using FLexElectronicsShop.Model;

namespace FLexElectronicsShop.Pages.StoreManagement.StoreCatalogManagement
{
    public class EditModel : PageModel
    {
        private readonly FLexElectronicsShop.Data.FEShopContext _context;

        public EditModel(FLexElectronicsShop.Data.FEShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CatalogItem CatalogItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogitem =  await _context.CatalogItems.FirstOrDefaultAsync(m => m.Id == id);
            if (catalogitem == null)
            {
                return NotFound();
            }
            CatalogItem = catalogitem;
           ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Description");
           ViewData["PromotionId"] = new SelectList(_context.Promotions, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (CatalogItem.PromotionId is not null)
            {
                CatalogItem.Promotion = await _context.Promotions.FirstAsync(p => p.Id == CatalogItem.PromotionId);
            }
            CatalogItem.DiscountedPrice = CatalogItem.ApplyDiscount(CatalogItem.Promotion, CatalogItem.DiscountedPrice, CatalogItem.Price);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CatalogItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogItemExists(CatalogItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CatalogItemExists(int id)
        {
            return _context.CatalogItems.Any(e => e.Id == id);
        }
    }
}
