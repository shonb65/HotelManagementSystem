using System;
using System.Threading.Tasks;
using HotelManagemnt.GuestService.Entities;
using System.Collections.Generic;

namespace HotelManagemnt.GuestService.Repositories
{
    public interface IReposetory<T> where T : IEntity
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}