using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightProject.Application.DTOs
{
    public class FlightCancelRequest
    {
        public string PnrNumber { get; set; }
        public string TicketNumber { get; set; }
    }
}
