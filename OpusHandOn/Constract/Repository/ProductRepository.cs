using OpusHandOn.Constract.IRepository;
using OpusHandOn.Data;
using OpusHandOn.Models;

namespace OpusHandOn.Constract.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
   {
      private readonly AppDbContext context;
      public ProductRepository(AppDbContext context) : base(context)
      {
         this.context = context;
      }

      public void Update(Product entity)
      {
         context.Product.Update(entity);
      }
   }
}
