using Shared.Pet.Entity;
using System.Linq.Expressions;

namespace Shared.Pet.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        //bool Update(T entity);
        Task<Guid> UpdateAsync(T entity);
        bool Delete(T entity);
        bool DeleteRange(List<T> entity);
        Task<int> SaveAsync();
        Task<T> GetByIdAsync(Guid id);
        //Task<bool> InsertAsync(T entity);
        Task<T> InsertAsync(T entity);
        //IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync();
        IEnumerable<T> GetByFilter(Func<T, bool> filter);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        //vermiş olduğumuz şarta uygun ilk tekil nesneyi getirir
    }
}
