using FlightProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject.Domain.Entities
{
    public class Flight : BaseEntity
    {
        public DateTime FlightDate { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public ICollection<Ticket>? Tickets { get; set; } // Uçuşun sahip olduğu biletler
    }
}
