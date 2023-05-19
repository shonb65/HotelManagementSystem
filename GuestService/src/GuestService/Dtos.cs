using System.ComponentModel.DataAnnotations;
using System;

namespace HotelManagemnt.GuestService.Dtos
{
    public record GuestDto(Guid Id, string FirstName, string LastName);

    public record CreateGuestDto([Required] string FirstName,[Required] string LastName);

    public record UpdateGuestDto([Required] string FirstName,[Required] string LastName);

}