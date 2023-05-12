using Shared.Pet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Pet.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        bool Update(T entity);
        bool Delete(T entity);
        bool DeleteRange(List<T> entity);
        Task<int> SaveAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> AddAsync(T entity);
        IQueryable<T> GetAll();
        IEnumerable<T> GetByFilter(Func<T, bool> filter);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        //vermiş olduğumuz şarta uygun ilk tekil nesneyi getirir
    }
}
