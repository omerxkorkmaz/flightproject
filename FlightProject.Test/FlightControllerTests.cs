using FlightProject.API.Controllers;
using FlightProject.Application.DTOs;
using FlightProject.Application.IRepositories;
using FlightProject.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq.Expressions;
using System.Net.Sockets;


namespace FlightProject.Test
{
    public class FlightControllerTests
    {
        private readonly Mock<IReadRepository<Ticket>> _mockTicketReadRepository;

        private readonly Mock<IWriteRepository<Ticket>> _mockTicketWriteRepository;

        private readonly Mock<IReadRepository<Flight>> _mockFlightReadRepository;

        private readonly Mock<IWriteRepository<Flight>> _mockFlightWriteRepository;

        private readonly FlightController _controller;

        public FlightControllerTests()
        {
            _mockTicketReadRepository = new Mock<IReadRepository<Ticket>>();

            _mockTicketWriteRepository = new Mock<IWriteRepository<Ticket>>();

            _mockFlightReadRepository = new Mock<IReadRepository<Flight>>();

            _mockFlightWriteRepository = new Mock<IWriteRepository<Flight>>();

            _controller = new FlightController(
                _mockTicketReadRepository.Object,
                 _mockFlightReadRepository.Object,
                _mockTicketWriteRepository.Object,                
                _mockFlightWriteRepository.Object);
        }


        [Fact]
        public void VoidTicket_ReturnsOk_WhenTicketIsCancelled()
        {
        
            var request = new FlightCancelRequest { PnrNumber = "123", TicketNumber = "456" };
            var ticket = new Ticket { PNRNumber = "123", TicketNumber = "456" };
     

            _mockTicketReadRepository.Setup(repo => repo.GetFlight(It.IsAny<Expression<Func<Ticket, bool>>>()))
                         .Returns(new List<Ticket> { ticket }.AsQueryable());


         
            var result = _controller.VoidTicket(request);

      
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Bilet başarıyla iptal edildi.", okResult.Value);
        }

        [Fact]
        public void VoidTicket_ReturnsNotFound_WhenTicketDoesNotExist()
        {
         
            var request = new TicketReissueRequest
            {
                PnrNumber = "123",
                Departure = "IST",
                Arrival = "JFK",
                NewFlightDate = new DateTime(2024, 06, 10)
            };

            var ticket = new Ticket
            {
                PNRNumber = "123",
                TicketNumber = "456",
                Departure = "OldDeparture",
                Arrival = "OldArrival",
                FlightDate = new DateTime(2024, 06, 08)
            };

            var newFlight = new Flight
            {              
                Departure = "IST",
                Arrival = "JFK",
                FlightDate = new DateTime(2024, 06, 10)
            };

            _mockTicketReadRepository.Setup(repo => repo.GetFlight(It.IsAny<Expression<Func<Ticket, bool>>>()))
                                     .Returns(new List<Ticket> { ticket }.AsQueryable());

            _mockFlightReadRepository.Setup(repo => repo.GetNewFlight(It.IsAny<Expression<Func<Flight, bool>>>()))
                                     .Returns(new List<Flight> { newFlight }.AsQueryable());



            var result = _controller.ReissueTicket(request);


          
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Bilet başarıyla değiştirildi...", okResult.Value);
        }


    }
}

