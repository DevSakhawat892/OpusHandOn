using Microsoft.EntityFrameworkCore;
using OpusHandOn.Constract.IRepository;
using OpusHandOn.Data;
using System.Linq.Expressions;

namespace OpusHandOn.Constract.Repository
{
    public class Repository<T> : IRepository<T> where T : class
   {
      private readonly AppDbContext context;
      internal DbSet<T> dbSet;

      public Repository(AppDbContext context)
      {
         this.context = context;
         dbSet = context.Set<T>();
      }

      public IEnumerable<T> QueryAsync(Expression<Func<T, bool>>? filter, string? includeProperties = null)
      {
         IQueryable<T> query = dbSet;
         if (filter != null)
         {
            query = dbSet.Where(filter);
         }
         query = query.AsQueryable().AsNoTracking();

         if (includeProperties != null)
         {
            foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
               query = query.Include(includeProp);
            }
         }
         return query.ToList();
      }

      public T FirstOrDefault(Expression<Func<T, bool>>? filter, string? includeProperties = null)
      {
         IQueryable<T> query = dbSet;
         query = query.Where(filter);
         if (includeProperties != null)
         {
            foreach (var includeProp in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
               query = query.Include(includeProp);
            }
         }
         return query.FirstOrDefault();
      }

      public void Add(T entity)
      {
         dbSet.Add(entity);
      }

      public void Remove(T entity)
      {
         dbSet.Remove(entity);
      }

      public void RemoveRange(IEnumerable<T> entity)
      {
         dbSet.RemoveRange(entity);
      }
   }
}
