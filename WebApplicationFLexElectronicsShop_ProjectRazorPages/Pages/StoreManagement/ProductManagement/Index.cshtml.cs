﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FLexElectronicsShop.Data;
using FLexElectronicsShop.Model;

namespace FLexElectronicsShop.Pages.StoreManagement.ProductManagement
{
    public class IndexModel : PageModel
    {
        private readonly FLexElectronicsShop.Data.FEShopContext _context;

        public IndexModel(FLexElectronicsShop.Data.FEShopContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category).ToListAsync();
        }
    }
}
