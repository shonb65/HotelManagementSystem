using HotelManagemnt.Common;

namespace HotelManagemnt.ReservationService.Entities
{
    public class ReservationItem : IEntity
    {
        public Guid Id { get; set; }
        public Guid guestId { get; set; }
        public Guid reservationId { get; set; }
        public int roomId { get; set; }
        public DateTimeOffset startDate { get; set; }
        public DateTimeOffset endDate { get; set; }
        public int totalPrice { get; set; }
    }
}