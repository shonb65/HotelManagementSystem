using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelManagemnt.GuestService.Dtos;
using System.Linq;

namespace HotelManagemnt.GuestService.Controllers
{
    [ApiController]
    [Route("guests")]
    public class GuestsController : ControllerBase
    {
        private static readonly List<GuestDto> guests = new()
        {
            new GuestDto(Guid.NewGuid(), "Shon", "Buch"),
            new GuestDto(Guid.NewGuid(), "Shon1", "Buch1"),
            new GuestDto(Guid.NewGuid(), "Shon2", "Buch2")
        };

        [HttpGet]
        public IEnumerable<GuestDto> Get()
        {
            return guests;
        }

        [HttpGet("{id}")]
        public GuestDto GetById(Guid id)
        {
            var guest = guests.Where(guest => guest.Id == id).SingleOrDefault();
            return guest;
        }

    }
}