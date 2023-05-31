using HotelManagemnt.Common;

namespace HotelManagemnt.HotelService.Entities
{
    public class Room : IEntity
    {
        public Guid Id { get; set; }

        public int RoomNumber { get; set; }

        public string RoomStatus { get; set; }

    }
}