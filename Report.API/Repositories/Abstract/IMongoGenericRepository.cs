using System.Linq.Expressions;

namespace Report.API.Repositories.Abstract
{
    public interface IMongoGenericRepository<T> where T :class
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(Expression<Func<T, bool>> predicate);
        Task InsertAsync(T entity);
        Task BulkInsert(List<T> entity);
        Task Update(T entity, Expression<Func<T, bool>> predicate);
        void Delete(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllById(Expression<Func<T, bool>> predicate);
    }
}
