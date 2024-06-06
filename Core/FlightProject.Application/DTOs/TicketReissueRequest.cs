using FlightProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject.Application.DTOs
{
    public class TicketReissueRequest
    {
        public string? LastName { get; set; }
        public string? PnrNumber { get; set; }
        public DateTime NewFlightDate { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
  
    }
}
