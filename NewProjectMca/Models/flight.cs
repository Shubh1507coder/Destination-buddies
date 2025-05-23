using BookingTickets.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewProjectMca.Models
{
    public class flight
    {
        [Key]
        public int f_id { get; set; }
        public string? f_from { get; set; }
        public string? f_to { get; set; }
        public string? f_email { get; set; }
        public int? passengers { get; set; }
        public DateTime? f_date { get; set; }
        public string? price { get; set; } 

        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public user users { get; set; }

    }
}
