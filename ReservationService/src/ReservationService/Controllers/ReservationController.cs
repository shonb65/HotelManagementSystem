using HotelManagemnt.Common;
using HotelManagemnt.ReservationService.Entities;
using Microsoft.AspNetCore.Mvc;
using HotelManagemnt.ReservationService.Dtos;
using HotelManagemnt.ReservationService.Extensions;
using MassTransit;
using HotelManagemnt.ReservationServiceContracts;

namespace HotelManagemnt.ReservationService.Controllers
{
    [ApiController]
    [Route("reservation")]
    public class ReservationController : ControllerBase
    {
        private readonly IReposetory<Reservation> reservationsRepository;
        private readonly IPublishEndpoint publishEndpoint;
        

        public ReservationController(IReposetory<Reservation> reservationsRepository, IPublishEndpoint publishEndpoint)
        {
            this.reservationsRepository = reservationsRepository;
            this.publishEndpoint = publishEndpoint;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDto>> GetReservationAsync(Guid id)
        {
            var reservation = await reservationsRepository.GetAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation.AsReservationDto();
        }


        [HttpGet("user")]
        public async Task<ActionResult<IEnumerable<GuestReservationDto>>> GetReservationByGuestIdAsync(Guid guestId)
        {
            if (guestId == Guid.Empty)
            {
                return BadRequest();
            }

            var reservations = (await reservationsRepository.GetAllAsync(reservation => reservation.GuestId == guestId))
                                .Select(reservation => reservation.AsGuestReservationDto());

            return Ok(reservations);
        }

        [HttpPost]
        public async Task<ActionResult<ReservationDto>> PostAsync(CreateReservationDto createReservationDto)
        {    
            // also needsto check if exist        
            if (createReservationDto.guestId == Guid.Empty)
            {
                return BadRequest();
            }

            var reservation = new Reservation
            {
                Id = new Guid(),
                GuestId = createReservationDto.guestId,
                RoomId = createReservationDto.roomId,
                StartDate = createReservationDto.startDate,
                EndDate = createReservationDto.endDate,
                TotalPrice = createReservationDto.totalPrice
            };

            await reservationsRepository.CreateAsync(reservation);

            string roomStatus = "Not available";

            await publishEndpoint.Publish(new ReservationCreated(reservation.Id, reservation.RoomId, roomStatus));

            return CreatedAtAction(nameof(GetReservationAsync), new { id = reservation.Id }, reservation);
        }


    }
}