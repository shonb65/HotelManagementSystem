using System.Collections.Generic;
using HotelManagemnt.Common;
using System;


namespace HotelManagemnt.HotelService.Entities
{
    public class Hotel : IEntity
    {
        public Guid Id { get; set; }

        public string HotelName { get; set; }

        public List<Room> Rooms { get; set; }
    }
}