using HotelManagemnt.ReservationService.Dtos;
using HotelManagemnt.ReservationService.Entities;


namespace HotelManagemnt.ReservationService.Extensions
{
    public static class Extensions
    {
        public static ReservationDto AsReservationDto(this Reservation reservation)
        {
            return new ReservationDto(reservation.Id, reservation.GuestId, reservation.RoomId, reservation.StartDate, reservation.EndDate, reservation.TotalPrice);
        }

        public static GuestReservationDto AsGuestReservationDto(this Reservation reservation)
        {
            return new GuestReservationDto(reservation.GuestId, reservation.RoomId, reservation.StartDate, reservation.EndDate, reservation.TotalPrice);
        }
    }
}