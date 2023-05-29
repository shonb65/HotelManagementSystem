using HotelManagemnt.ReservationService.Dtos;
using HotelManagemnt.ReservationService.Entities;

namespace HotelManagemnt.ReservationService.Extensions
{
    public static class Extensions
    {
        public static ReservationDto AsDto(this ReservationItem reservationItem)
        {
            return new ReservationDto(reservationItem.reservationId, reservationItem.guestId, reservationItem.roomId, reservationItem.startDate, reservationItem.endDate, reservationItem.totalPrice);
        }
    }
}