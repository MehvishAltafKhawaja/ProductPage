using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class ProductdbContext: DbContext
    {

        public ProductdbContext(DbContextOptions<ProductdbContext> options)
          : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
