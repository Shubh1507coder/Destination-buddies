using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewProjectMca.Models
{
    public class booktrip
    {
        [Key]
        public int b_id { get; set; }

        public string? trip_from { get; set; }
        public string? trip_to { get; set; }


        public int? passengers { get; set; }
        public DateTime? trip_date { get; set; }
        public int price { get; set; } = 14000;

        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public user users { get; set; }

    }
}
