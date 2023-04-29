using OpusHandOn.Constract.IRepository;
using OpusHandOn.Data;
using OpusHandOn.Models;

namespace OpusHandOn.Constract.Repository
{
    public class SalesMasterRepository : Repository<SalesMaster>, ISalesMasterRepository
   {
      private readonly AppDbContext context;

      public SalesMasterRepository(AppDbContext context) : base(context)
      {
         this.context = context;
      }

      public void Update(SalesMaster entity)
      {
         context.SalesMasters.Update(entity);
      }
   }
}
