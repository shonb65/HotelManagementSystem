using HotelManagemnt.Common;
using HotelManagemnt.ReservationService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagemnt.ReservationService.Controllers
{
    [ApiController]
    [Route("reservation")]
    public class ReservationController : ControllerBase
    {
        private readonly IReposetory<Reservation> reservationRepository;

        public ReservationController(IReposetory<Reservation> reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto


    }
}