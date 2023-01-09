using Pet_Store.Data.Entities;
using Pet_Store.Data.UnitOfWork;
using System.Linq.Expressions;

namespace Pet_Store.Data.RepositoryEF
{
    public partial interface IRepositoryEF<T> where T : BaseEntity
    {
        public IUnitOfWork UnitOfWork { get; }

        Task<T> GetFirstAsync(Guid id);

        Task<T> GetFirstAsyncAsNoTracking(Guid id);

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> ListAllAsync();

        void Update(T entity);

        void Delete(T entity);

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int records = 0,
               string includeProperties = "");

        public Task<IEnumerable<T>> GetAync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int records = 0,
        string includeProperties = "");
    }
}