using FlightProject.Application.DTOs;
using FlightProject.Application.IRepositories;
using FlightProject.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlightProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IReadRepository<Ticket> _ticketReadRepository;
        private readonly IReadRepository<Flight> _flightReadRepository;
        private readonly IWriteRepository<Ticket> _ticketWriteRepository;
        private readonly IWriteRepository<Flight> _flightWriteRepository;


        public FlightController(IReadRepository<Ticket> ticketReadRepository, IReadRepository<Flight> flightReadRepository, IWriteRepository<Ticket> ticketWriteRepository, IWriteRepository<Flight> flightWriteRepository)
        {
            _ticketReadRepository = ticketReadRepository;
            _ticketWriteRepository = ticketWriteRepository;
            _flightReadRepository = flightReadRepository;
            _flightWriteRepository = flightWriteRepository;

        }

        [HttpPost]
        public IActionResult VoidTicket(FlightCancelRequest request)
        {

            var ticket = _ticketReadRepository.GetFlight(x => x.PNRNumber == request.PnrNumber && x.TicketNumber == request.TicketNumber).FirstOrDefault();

            if (ticket == null)         
                return NotFound("Böyle bir bilet yok");     

            ticket.IsCancelled = true;

            _ticketWriteRepository.Update(ticket);

            return Ok("Bilet başarıyla iptal edildi.");
        }

        [HttpPost]
        public IActionResult ReissueTicket(TicketReissueRequest request)
        {

            var ticket = _ticketReadRepository.GetFlight(t => t.PNRNumber == request.PnrNumber).FirstOrDefault();

            if (ticket == null)            
                return NotFound("Böyle bir bilet yok");       

            var newFlight = _flightReadRepository.GetNewFlight(t => t.FlightDate.Date == request.NewFlightDate.Date && t.Departure == request.Departure && t.Arrival == request.Arrival).FirstOrDefault();

            if (newFlight == null)         
                return NotFound("Böyle bir uçuş yok");     

            ticket.Departure = newFlight.Departure;
            ticket.Arrival = newFlight.Arrival;
            ticket.FlightDate = newFlight.FlightDate;
            ticket.FlightId = newFlight.Id;

            _ticketWriteRepository.Update(ticket);

            return Ok("Bilet başarıyla değiştirildi...");
        }
    }
}
