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

        // GET /guests/{id}
        [HttpGet("{id}")]
        public GuestDto GetById(Guid id)
        {
            var guest = guests.Where(guest => guest.Id == id).SingleOrDefault();
            return guest;
        }

        [HttpPost]
        public ActionResult<GuestDto> Post(CreateGuestDto createGuestDto)
        {
            var guest = new GuestDto(Guid.NewGuid(), createGuestDto.FirstName, createGuestDto.LastName);
            guests.Add(guest);
            return CreatedAtAction(nameof(GetById), new { id = guest.Id }, guest);
        }

        // PUT /guests/{id}
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UpdateGuestDto updateGuestDto)
        {
            var existingGuest = guests.Where(guest => guest.Id == id).SingleOrDefault();

            var updatedGuest = existingGuest with{
                FirstName = updateGuestDto.FirstName,
                LastName = updateGuestDto.LastName
            };

            var index = guests.FindIndex(existingGuest => existingGuest.Id == id);
            guests[index] = updatedGuest;

            return NoContent();
        }

    }
}