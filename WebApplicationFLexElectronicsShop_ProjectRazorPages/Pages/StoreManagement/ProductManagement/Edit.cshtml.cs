using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FLexElectronicsShop.Data;
using FLexElectronicsShop.Model;
using FLexElectronicsShop.Services.Interfaces;
using FLexElectronicsShop.ViewModel;

namespace FLexElectronicsShop.Pages.StoreManagement.ProductManagement
{
    public class EditModel : PageModel
    {
        private readonly FLexElectronicsShop.Data.FEShopContext _context;
        private IPhotoService PhotoService;
        public EditModel(FLexElectronicsShop.Data.FEShopContext context, IPhotoService photoService)
        {
            _context = context;
            PhotoService = photoService;
        }

        [BindProperty]
        public ProductViewModel Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product =  await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            Product = new ProductViewModel
            {
                Id = product.Id,
                Title = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                URL = null
            };
           ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == Product.Id);

            if(Product.URL is not null)
            {
                await PhotoService.DeletePhotoAsync(product.URL);
                var resultAddPhoto = await PhotoService.AddPhotoAsync(Product.URL);
                product.URL = resultAddPhoto.Url.ToString();
            }

            product.Name = Product.Title;
            product.Description = Product.Description;
            product.CategoryId = Product.CategoryId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.Id))
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

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
