using System.ComponentModel.DataAnnotations;

namespace BookingTickets.Models
{
    public class adminlogin
    {
        [Key]
        public int admin_id { get; set; }

        public string admin_email { get; set; }

        public string admin_password { get; set; }
    }
}
