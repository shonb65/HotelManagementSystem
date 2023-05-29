using HotelManagemnt.Common;

namespace HotelManagemnt.ReservationService.Entities
{
    public class ReservationItem : IEntity
    {
        public Guid Id { get; set; }

        public Guid GuestId { get; set; }

        public int reservationId { get; set; }
        public int roomId { get; set; }
        DateTimeOffset startDate { get; set; }
        DateTimeOffset endDate { get; set; }
        public int totalPrice { get; set; }
    }
}