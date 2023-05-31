using System.ComponentModel.DataAnnotations;

namespace HotelManagemnt.ReservationService.Dtos
{
    public record ReservationDto(Guid id, Guid guestId, int roomId, DateTimeOffset startDate, DateTimeOffset endDate, int totalPrice);

    public record GuestReservationDto(Guid guestId, int roomId, DateTimeOffset startDate, DateTimeOffset endDate, int totalPrice);

    public record CreateReservationDto([Required] Guid guestId, [Required] int roomId, [Required] DateTimeOffset startDate, [Required] DateTimeOffset endDate, [Required] int totalPrice);
}