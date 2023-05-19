using HotelManagemnt.GuestService.Dtos;
using HotelManagemnt.GuestService.Entities;

namespace HotelManagemnt.GuestService
{
    public static class Extensions
    {
        public static GuestDto AsDto(this Guest guest)
        {
            return new GuestDto(guest.Id, guest.FirstName, guest.LastName);
        }
    }
}