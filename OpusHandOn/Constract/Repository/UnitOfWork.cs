using OpusHandOn.Constract.IRepository;
using OpusHandOn.Data;

namespace OpusHandOn.Constract.Repository
{
    public class UnitOfWork : IUnitOfWork
   {
      private readonly AppDbContext context;

      public UnitOfWork(AppDbContext context)
      {
         this.context = context;
         Product = new ProductRepository(context);
         SalesMaster = new SalesMasterRepository(context);
         SalesDetail = new SalesDetailRepository(context);
      }

      public void Save()
      {
         context.SaveChanges();
      }

      public IProductRepository Product { get; private set; }
      public ISalesMasterRepository SalesMaster { get; private set; }
      public ISalesDetailRepository SalesDetail { get; private set; }
   }
}
