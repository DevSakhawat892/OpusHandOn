using OpusHandOn.Models;

namespace OpusHandOn.Constract.IRepository
{
    public interface ISalesDetailRepository : IRepository<SalesDetail>
    {
        void Update(SalesDetail entity);
    }
}