using System.Linq.Expressions;

namespace OpusHandOn.Constract.IRepository
{
    public interface IRepository<T> where T : class
    {
        T FirstOrDefault(Expression<Func<T, bool>>? filter, string? includeProperties = null);
        IEnumerable<T> QueryAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}