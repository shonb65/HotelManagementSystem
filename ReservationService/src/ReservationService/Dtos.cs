namespace HotelManagemnt.ReservationService.Dtos
{
    public record ReservationDto(Guid reservationId, Guid guestId,int roomId, DateTimeOffset startDate, DateTimeOffset endDate, int totalPrice);
}