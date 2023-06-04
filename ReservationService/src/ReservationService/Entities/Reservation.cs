using Hotel.Common;

namespace HotelManagemnt.ReservationService.Entities
{
    public class Reservation : IEntity
    {
        public Guid Id { get; set; }
        public Guid GuestId { get; set; }
        public int RoomId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int TotalPrice { get; set; }
    }
}