using BookingTickets.Models;
using NewProjectMca.Models;
using System.Diagnostics;

namespace NewProjectMca.Models
{
    public class TicketViewModel
    {
        public List<bus> Buses { get; set; }
        public List<train> Trains { get; set; }
        public List<flight> Flights { get; set; }
        public List<booktrip> booktrips { get; set; }
    }
}
