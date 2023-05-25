using System.Runtime.InteropServices;
using System.Net;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelManagemnt.GuestService.Dtos;
using System.Linq;
using HotelManagemnt.GuestService.Entities;
using HotelManagemnt.Common.Settings;
using HotelManagemnt.Common;

namespace HotelManagemnt.GuestService.Controllers
{
    [ApiController]
    [Route("guests")]
    public class GuestsController : ControllerBase
    {
        private readonly IReposetory<Guest> guestsReposetory;

        public GuestsController(IReposetory<Guest> guestsReposetory)
        {
            this.guestsReposetory = guestsReposetory;
        }

        [HttpGet]
        public async  Task<IEnumerable<GuestDto>> GetAsync()
        {
            var guests = (await guestsReposetory.GetAllAsync())
                        .Select(item => item.AsDto());

            return guests;
        }

        // GET /guests/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDto>> GetByIdAsync(Guid id)
        {
            var guest = await guestsReposetory.GetAsync(id);

            if(guest == null)
            {
                return NotFound();
            }

            return guest.AsDto();
        }

        // POST /guestsks
        [HttpPost]
        public async Task<ActionResult<GuestDto>> PostAsync(CreateGuestDto createGuestDto)
        {
            var guest = new Guest
            {
                FirstName = createGuestDto.FirstName,
                LastName = createGuestDto.LastName
            };
            
            await guestsReposetory.CreateAsync(guest);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = guest.Id }, guest);
        }

        // PUT /guests/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateGuestDto updateGuestDto)
        {
            var existingGuest = await  guestsReposetory.GetAsync(id);

            if (existingGuest == null)
            {
                return NotFound();
            }

            existingGuest.FirstName = updateGuestDto.FirstName;
            existingGuest.LastName = updateGuestDto.LastName;

            await guestsReposetory.UpdateAsync(existingGuest);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var guest = await  guestsReposetory.GetAsync(id);

            if (guest == null)
            {
                return NotFound();
            }

            await guestsReposetory.RemoveAsync(guest.Id);

            return NoContent();
        }
    }
}