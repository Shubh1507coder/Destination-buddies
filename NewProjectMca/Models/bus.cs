using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BookingTickets.Models;

namespace NewProjectMca.Models
{
    public class bus
    {
        [Key]
        public int b_id { get; set; }
        public string? b_from { get; set; }
        public string? b_to { get; set; }
 
        public int? passengers { get; set; }
        public DateTime? b_date { get; set; }
     
        public string? price { get; set; }

        public string? paymentId { get; set; }

        public int user_id { get; set; }

        [ForeignKey("user_id")]
        public user users { get; set; }
    }
}
