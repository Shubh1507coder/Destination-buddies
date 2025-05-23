using BookingTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewProjectMca.Models;
using Razorpay.Api;

namespace BookingTickets.Controllers
{
    public class payment : Controller
    {
        private readonly IConfiguration _config; private readonly TicketDBContext _context;
        public payment(IConfiguration config, TicketDBContext context)
        {
            _config = config;
            _context = context;
        }

        public IActionResult CreateOrder(int amount)
        {
            string key = _config["rzp_test_vTbEoID02du5vk"];
            string secret = _config["YtDIHIpeluslMkGM0dQjHoHD"];

            RazorpayClient client = new RazorpayClient(key, secret);

            Dictionary<string, object> options = new Dictionary<string, object>
        {
            { "amount", amount * 100 },  
            { "currency", "INR" },
            { "payment_capture", "1" }  
        };

            Order order = client.Order.Create(options);

            return Json(new { orderId = order["id"] });
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost("payment")]
        public IActionResult SaveTicket([FromBody] bus ticket)
        {
            Console.WriteLine("Received Payment Request: " + ticket.b_id);

            if (ticket == null || string.IsNullOrEmpty(ticket.paymentId))

            {
                return BadRequest(new { success = false, message = "Invalid Data" });
            }

            try
            {
                
                _context.tbl_bus.Add(ticket);
                _context.SaveChanges();

                return Ok(new { success = true, message = "Ticket booked successfully!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return StatusCode(500, new { success = false, message = "Internal Server Error" });
            }
        }

    }
}
