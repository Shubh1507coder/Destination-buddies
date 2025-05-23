using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BookingTickets.Models;

namespace NewProjectMca.Models
{
    public class train
    {
        [Key]
        public int t_id { get; set; }
        public string? t_from { get; set; }
        public string? t_to { get; set; }

        public string? t_email { get; set; }
        public int? passengers { get; set; }
        public DateTime? t_date { get; set; }
        public int price { get; set; } = 400;


        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public user users { get; set; }
    }
}
