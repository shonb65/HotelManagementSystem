using System;
namespace HotelManagemnt.GuestService.Entities
{
    public class Guest
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}