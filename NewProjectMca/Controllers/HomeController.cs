using BookingTickets.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NewProjectMca.Models;

namespace NewProjectMca.Controllers
{
    public class HomeController : Controller
    {
        private readonly TicketDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(TicketDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult User()
        {

            return View();
        }

        [HttpPost]
        public IActionResult User(user u)
        {
            _context.tbl_user.Add(u);
            _context.SaveChanges();
            return RedirectToAction("index", "home");
        }



        public IActionResult Login()
        {
            var user = HttpContext.Session.GetString("user_session");
            if (user != null)
            {
                return View("Index");
            }
            else
            {
                return View("login");
            }
        }


        public IActionResult user_login(string user_email, string user_password)
        {
            var row = _context.tbl_user.FirstOrDefault(a => a.user_email == user_email);
            if (row != null && row.user_password == user_password)
            {
                HttpContext.Session.SetString("user_session", row.user_id.ToString());
                ViewBag.Name = row.user_name;
                TempData["Messagelogin"] = "Login Successful! Welcome back.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = "Email and Password is incorrect!!";
                return RedirectToAction("login", "home");
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user_session");
            return RedirectToAction("index", "Home");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            ViewBag.checksession = HttpContext.Session.GetString("user_session");


            string userSession = HttpContext.Session.GetString("user_session");

            if (!string.IsNullOrEmpty(userSession))
            {
                int userId = int.Parse(userSession);  // Convert session value to user_id (assuming it's an integer)
                var user = _context.tbl_user.FirstOrDefault(u => u.user_id == userId);  // Query the user details

                if (user != null)
                {
                    ViewBag.userId = user.user_id;
                    ViewBag.userName = user.user_name;
                    ViewBag.userEmail = user.user_email;
                    ViewBag.userNumber = user.user_phone;

                    // Store any other user details you want in ViewBag or ViewData
                }
            }



            base.OnActionExecuting(context);
        }

        [HttpPost]
        public async Task<IActionResult> Train(train a)
        {
            // Check if user is logged in
            var userSession = HttpContext.Session.GetString("user_session");

            if (userSession == null)
            {
                TempData["error"] = " 🔒 You must be logged in to access this page";
                return RedirectToAction("login", "home"); // Redirect to login page
            }

            // Assuming the user_session holds the user ID (adjust based on your session data structure)
            var userId = Convert.ToInt32(userSession); // Convert the session string to integer if it's the user ID

            // Set the user_id on the train object to establish the foreign key relationship



            // Add the incoming train data object to the database
            _context.tbl_train.Add(a);
            a.user_id = userId;
            await _context.SaveChangesAsync();  // Save changes asynchronously

            // Success message
            TempData["Message"] = "Train ticket booked successfully! You can check our Ticket and proceed to payment.";

            // Return a view (this can redirect or render confirmation)
            return RedirectToAction("index", "home");


            // In case of invalid form, return the same view

        }



        [HttpPost]
        public async Task<IActionResult> Bus(bus B)
        {
            // Check if user is logged in
            var userSession = HttpContext.Session.GetString("user_session");

            if (userSession == null)
            {
                TempData["error"] = " 🔒 You must be logged in to access this page";
                return RedirectToAction("login", "home"); // Redirect to login page
            }

            // Assuming the user_session holds the user ID (adjust based on your session data structure)
            var userId = Convert.ToInt32(userSession); // Convert the session string to integer if it's the user ID

            // Set the user_id on the train object to establish the foreign key relationship



            // Add the incoming train data object to the database
            _context.tbl_bus.Add(B);
            B.user_id = userId;
            await _context.SaveChangesAsync();  // Save changes asynchronously

            // Success message
            TempData["Message"] = "Bus ticket booked successfully! You can check our Ticket and proceed to payment.";


            // Return a view (this can redirect or render confirmation)
            return RedirectToAction("index","home");


            // In case of invalid form, return the same view

        }


        [HttpPost]
        public async Task<IActionResult> Flight(flight F)
        {
            // Check if user is logged in
            var userSession = HttpContext.Session.GetString("user_session");

            if (userSession == null)
            {
                TempData["error"] = " 🔒 You must be logged in to access this page";
                return RedirectToAction("Login", "home");
            }


            var userId = Convert.ToInt32(userSession);





            _context.tbl_flight.Add(F);
            F.user_id = userId;
            await _context.SaveChangesAsync();


            TempData["Message"] = "Flight ticket booked successfully! You can check our Ticket and proceed to payment.";


            return RedirectToAction("index", "home");




        }


        [HttpPost]
        public async Task<IActionResult> book(booktrip F)
        {

            var userSession = HttpContext.Session.GetString("user_session");

            if (userSession == null)
            {
                TempData["error"] = " 🔒 You must be logged in to access this page";
                return RedirectToAction("Login", "admin");
            }


            var userId = Convert.ToInt32(userSession);





            _context.tbl_booktrips.Add(F);
            F.user_id = userId;
            await _context.SaveChangesAsync();


            TempData["Message"] = "Your Trip is Booked, Our team will contact you soon.";



            return RedirectToAction("index", "home");



        }

        [HttpPost]
        public IActionResult contact(contact t)
        {
            _context.tbl_contact.Add(t);
            _context.SaveChanges();
            TempData["Message"] = "Your Query Submitted,Our team will contact you soon.";
            return RedirectToAction("index", "home");
        }

        public IActionResult guide()
        {
            return View();
        }

        public IActionResult aboutus()
        {
            return View();
        }

        public IActionResult contactus()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OurTicket()
        {
            // ✅ Check if user is logged in
            var userSession = HttpContext.Session.GetString("user_session");

            if (string.IsNullOrEmpty(userSession))
            {
                return RedirectToAction("Login", "admin"); // Redirect to login page if not logged in
            }

            // ✅ Convert session to integer
            if (!int.TryParse(userSession, out int userId))
            {
                return RedirectToAction("Login", "admin");
            }

            // ✅ Fetch tickets from all three tables where UserId matches session user ID
            var trainTickets = _context.tbl_train.Where(t => t.user_id == userId).ToList();
            var flightTickets = _context.tbl_flight.Where(f => f.user_id == userId).ToList();
            var busTickets = _context.tbl_bus.Where(b => b.user_id == userId).ToList();
            var booktrips = _context.tbl_booktrips.Where(b => b.user_id == userId).ToList();

            // ✅ Create a ViewModel to hold all ticket types
            var model = new TicketViewModel
            {
                Trains = trainTickets,
                Flights = flightTickets,
                Buses = busTickets,
                booktrips = booktrips
            };

            return View(model); // Pass the ViewModel to the view
        }


        [HttpPost]
        public IActionResult CancelBusTicket(int id)
        {
            var ticket = _context.tbl_bus.FirstOrDefault(b => b.b_id == id);
            if (ticket != null)
            {
                _context.tbl_bus.Remove(ticket);
                _context.SaveChanges();
                return Json(new { success = true, message = "Bus ticket cancelled successfully!" });
            }

            return Json(new { success = false, message = "Bus ticket not found!" });
        }

        [HttpPost]
        public IActionResult CancelFlightTicket(int id)
        {
            var ticket = _context.tbl_flight.FirstOrDefault(f => f.f_id == id);
            if (ticket != null)
            {
                _context.tbl_flight.Remove(ticket);
                _context.SaveChanges();
                return Json(new { success = true, message = "Flight ticket cancelled successfully!" });
            }

            return Json(new { success = false, message = "Flight ticket not found!" });
        }

        [HttpPost]
        public IActionResult CancelTrainTicket(int id)
        {
            var ticket = _context.tbl_train.FirstOrDefault(t => t.t_id == id);
            if (ticket != null)
            {
                _context.tbl_train.Remove(ticket);
                _context.SaveChanges();
                return Json(new { success = true, message = "Train ticket cancelled successfully!" });
            }

            return Json(new { success = false, message = "Train ticket not found!" });
        }
    }
}
