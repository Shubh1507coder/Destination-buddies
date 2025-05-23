using NewProjectMca.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BookingTickets.Models
{
    public class user
    {
        [Key]
        public int user_id { get; set; }

        public string? user_name { get; set; }
        
        public string? user_email { get; set; }
        public string? user_phone { get; set; }
        public string? user_password { get; set; }


        // Initialize collections to avoid null reference exceptions
        public ICollection<bus> Buses { get; set; } = new List<bus>();
        public ICollection<train> Trains { get; set; } = new List<train>();
        public ICollection<flight> Flights { get; set; } = new List<flight>();
        public ICollection<booktrip> Booktrips { get; set; } = new List<booktrip>();
    }
}
