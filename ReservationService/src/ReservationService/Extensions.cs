using HotelManagemnt.ReservationService.Dtos;
using HotelManagemnt.ReservationService.Entities;


namespace HotelManagemnt.ReservationService.Extensions
{
    public static class Extensions
    {
        public static ReservationDto AsReservationDto(this Reservation reservation)
        {
            return new ReservationDto(reservation.reservationId, reservation.guestId, reservation.roomId, reservation.startDate, reservation.endDate, reservation.totalPrice);
        }

        public static GuestReservationDto AsGuestReservationDto(this Reservation reservation)
        {
            return new GuestReservationDto(reservation.guestId, reservation.roomId, reservation.startDate, reservation.endDate, reservation.totalPrice);
        }
    }
}