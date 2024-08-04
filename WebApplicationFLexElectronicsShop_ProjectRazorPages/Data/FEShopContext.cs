using FLexElectronicsShop.Model;
using Microsoft.EntityFrameworkCore;

namespace FLexElectronicsShop.Data
{
    public class FEShopContext(DbContextOptions<FEShopContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
    }
}
