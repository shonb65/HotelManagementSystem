using System;

namespace HotelManagemnt.GuestService.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}