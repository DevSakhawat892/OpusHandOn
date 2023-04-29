using Microsoft.EntityFrameworkCore;
using OpusHandOn.Models;

namespace OpusHandOn.Data
{
   public class AppDbContext : DbContext
   {
      public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
      {
      }

      public DbSet<Product> Product { get; set; }
      public DbSet<SalesMaster> SalesMasters { get; set; }
      public DbSet<SalesDetail> SalesDetails { get; set; }
   }
}
