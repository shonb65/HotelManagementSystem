using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
    
namespace Hotel.Common
{
    public interface IReposetory<T> where T : IEntity
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Guid id);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(T entity);
 
       }
}
