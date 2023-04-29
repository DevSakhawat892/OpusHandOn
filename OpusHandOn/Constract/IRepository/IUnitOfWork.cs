namespace OpusHandOn.Constract.IRepository
{
    public interface IUnitOfWork
    {
        void Save();
        IProductRepository Product { get; }
        ISalesMasterRepository SalesMaster { get; }
        ISalesDetailRepository SalesDetail { get; }
    }
}