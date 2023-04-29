using OpusHandOn.Models;

namespace OpusHandOn.Constract.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product entity);
    }
}