using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FLexElectronicsShop.Data;
using FLexElectronicsShop.Model;
using FLexElectronicsShop.Services.Interfaces;
using FLexElectronicsShop.ViewModel;
using FLexElectronicsShop.Services;

namespace FLexElectronicsShop.Pages.StoreManagement.ProductManagement
{
    public class CreateModel : PageModel
    {
        private readonly FLexElectronicsShop.Data.FEShopContext _context;
        private IPhotoService PhotoService;

        public CreateModel(FLexElectronicsShop.Data.FEShopContext context, IPhotoService photoService)
        {
            _context = context;
            PhotoService = photoService;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Description");
            return Page();
        }

        [BindProperty]
        public ProductViewModel Product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Product.URL is null)
            {
                return Page();
            }

            var resultAddPhoto = await PhotoService.AddPhotoAsync(Product.URL);
            var product = new Product
            {
                Name = Product.Title,
                Description = Product.Description,
                CategoryId = Product.CategoryId,
                URL = resultAddPhoto.Url.ToString()
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
