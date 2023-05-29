namespace HotelManagemnt.ReservationService.Dtos
{
    public record ReservationDto(int reservationId, int guestId,int roomId, DateTimeOffset startDate, DateTimeOffset endDate, int totalPrice);
}