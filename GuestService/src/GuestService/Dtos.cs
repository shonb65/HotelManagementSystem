using System;

namespace HotelManagemnt.GuestService.Dtos
{
    public record GuestDto(Guid Id, string FirstName, string LastName);

    public record CreateGuestDto(string FirstName, string LastName);

    public record UpdateGuestDto(string FirstName, string LastName);

}