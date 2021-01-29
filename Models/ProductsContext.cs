using Microsoft.EntityFrameworkCore;

namespace CRUDtest.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
