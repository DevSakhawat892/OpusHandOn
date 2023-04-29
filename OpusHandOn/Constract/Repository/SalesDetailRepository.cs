using OpusHandOn.Constract.IRepository;
using OpusHandOn.Data;
using OpusHandOn.Models;

namespace OpusHandOn.Constract.Repository
{
    public class SalesDetailRepository : Repository<SalesDetail>, ISalesDetailRepository
   {
      private readonly AppDbContext context;

      public SalesDetailRepository(AppDbContext context) : base(context)
      {
         this.context = context;
      }

      public void Update(SalesDetail entity)
      { 
         context.SalesDetails.Update(entity);
      }
   }
}
