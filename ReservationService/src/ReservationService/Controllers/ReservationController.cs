using HotelManagemnt.Common;
using HotelManagemnt.ReservationService.Entities;
using Microsoft.AspNetCore.Mvc;
using HotelManagemnt.ReservationService.Dtos;
using HotelManagemnt.ReservationService.Extensions;

namespace HotelManagemnt.ReservationService.Controllers
{
    [ApiController]
    [Route("reservation")]
    public class ReservationController : ControllerBase
    {
        private readonly IReposetory<Reservation> reservationsRepository;

        public ReservationController(IReposetory<Reservation> reservationsRepository)
        {
            this.reservationsRepository = reservationsRepository;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestReservationDto>>> GetReservationAsync(Guid guestId)
        {
            if (guestId == Guid.Empty)
            {
                return BadRequest();
            }

            var reservations = (await reservationsRepository.GetAllAsync(reservation => reservation.guestId == guestId))
                                .Select(reservation => reservation.AsGuestReservationDto());

            return Ok(reservations);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync()
        {
            return Ok();
        }


    }
}