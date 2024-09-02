using FLexElectronicsShop.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FLexElectronicsShop.Data
{
    public class FEShopContext(DbContextOptions<FEShopContext> options) : IdentityDbContext(options)
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CatalogItem> CatalogItems {  get; set; }

        public DbSet<Promotion> Promotions { get; set; }
    }
}
