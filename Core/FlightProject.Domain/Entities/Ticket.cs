using FlightProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public string? PNRNumber { get; set; }
        public string? TicketNumber { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public DateTime FlightDate { get; set; }
        public bool IsCancelled { get; set; }
        public int UserId { get; set; } // Foreign key for User
        public User? User { get; set; }
        public int FlightId { get; set; } // Foreign key for Flight
        public Flight? Flight { get; set; }

    }
}
