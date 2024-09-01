using FLexElectronicsShop.Model;
using Microsoft.EntityFrameworkCore;

namespace FLexElectronicsShop.Data
{
    public class FEShopContext(DbContextOptions<FEShopContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CatalogItem> CatalogItems {  get; set; }

        public DbSet<Promotion> Promotions { get; set; }
    }
}
