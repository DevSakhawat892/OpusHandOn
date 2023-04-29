using OpusHandOn.Models;

namespace OpusHandOn.Constract.IRepository
{
    public interface ISalesMasterRepository : IRepository<SalesMaster>
    {
        void Update(SalesMaster entity);
    }
}