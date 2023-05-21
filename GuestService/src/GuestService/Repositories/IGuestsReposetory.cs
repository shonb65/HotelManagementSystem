using System;
using System.Threading.Tasks;
using HotelManagemnt.GuestService.Entities;
using System.Collections.Generic;
    
    public interface IGuestsReposetory
    {
        Task CreateAsync(Guest entity);
        Task<IReadOnlyCollection<Guest>> GetAllAsync();
        Task<Guest> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guest entity);
    }