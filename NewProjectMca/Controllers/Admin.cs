using BookingTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookingTickets.Controllers
{
    public class Admin : Controller
    {
        private readonly TicketDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Admin(TicketDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("admin_session");
            if (user != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "admin");
            }
        }



        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Set the ViewData value
            ViewData["total_bus"] = _context.tbl_bus.Count();
            ViewData["total_flight"] = _context.tbl_flight.Count();
            ViewData["total_train"] = _context.tbl_train.Count();
            ViewData["total_trip"] = _context.tbl_booktrips.Count();
            

            base.OnActionExecuting(context);
        }
        public IActionResult Login()
        {
            var user = HttpContext.Session.GetString("admin_session");
            if (user != null)
            {
                return View("Index");
            }
            else
            {
                return View("login");
            }
        }


        [HttpPost]
        public IActionResult Login(string admin_email, string admin_password)
        {

            var login = _context.tbl_admin
                         .Where(a => a.admin_email == admin_email && a.admin_password == admin_password)
                         .FirstOrDefault();

            if (login != null)
            {

                HttpContext.Session.SetString("admin_session", login.admin_email);
                TempData["success"] = "Login Successful";
                return RedirectToAction("Index");
            }
            else
            {

                TempData["error"] = "Invalid username or password";
                return View("Login");
            }
        }
        public IActionResult AdminLogout()
        {
            HttpContext.Session.Remove("admin_session");
            return RedirectToAction("Login");
        }

        public IActionResult shiowBus()
        {
            return View(_context.tbl_bus.ToList());
        }
        public IActionResult showtarin()
        {
            return View(_context.tbl_train.ToList());
        }
        public IActionResult showflight()
        {
            return View(_context.tbl_flight.ToList());
        }

        public IActionResult showtrip()
        {
            return View(_context.tbl_booktrips.ToList());
        }

        public IActionResult showuser()
        {
            return View(_context.tbl_user.ToList());
        }


        public IActionResult adminLogin()
        
        {
            var user = HttpContext.Session.GetString("admin_session");
            if (user != null)
            {
                return View("Index");
            }
            else
            {
                return View("adminlogin");
            }
        }


        [HttpPost]
        public IActionResult adminLogin(string admin_email, string admin_password)
        {

            var login = _context.tbl_admin
                         .Where(a => a.admin_email == admin_email && a.admin_password == admin_password)
                         .FirstOrDefault();

            if (login != null)
            {

                HttpContext.Session.SetString("admin_session", login.admin_email);
                TempData["success"] = "Login Successful";
                return RedirectToAction("Index","admin");
            }
            else
            {

                TempData["error"] = "Invalid username or password";
                return View("Login");
            }
        }





        
        public IActionResult CancelBusTicketss(int id)
        {
            var ticket = _context.tbl_bus.FirstOrDefault(b => b.b_id == id);
            if (ticket != null)
            {
                _context.tbl_bus.Remove(ticket);
                _context.SaveChanges();
                return RedirectToAction("shiowbus","admin");
            }
            return View();
            
        }


        public IActionResult CancelFlightTickets(int id)
        {
            var ticket = _context.tbl_flight.FirstOrDefault(f => f.f_id == id);
            if (ticket != null)
            {
                _context.tbl_flight.Remove(ticket);
                _context.SaveChanges();
                return RedirectToAction("showflight", "admin");
            }

            return View();
        }

      
        public IActionResult CancelTrainTickets(int id)
        {
            var ticket = _context.tbl_train.FirstOrDefault(t => t.t_id == id);
            if (ticket != null)
            {
                _context.tbl_train.Remove(ticket);
                _context.SaveChanges();
                return RedirectToAction("showtarin", "admin"); ;
            }

            return View();
        }



        public IActionResult CancelTrip(int id)
        {
            var ticket = _context.tbl_booktrips.FirstOrDefault(t => t.b_id == id);
            if (ticket != null)
            {
                _context.tbl_booktrips.Remove(ticket);
                _context.SaveChanges();
                return RedirectToAction("showtrip", "admin"); ;
            }

            return View();
        }
        public IActionResult DeleteUser(int id)
        {
            var ticket = _context.tbl_user.FirstOrDefault(t => t.user_id == id);
            if (ticket != null)
            {
                _context.tbl_user.Remove(ticket);
                _context.SaveChanges();
                return RedirectToAction("showuser", "admin"); ;
            }

            return View();
        }

        public IActionResult showcontact()
        {
            return View(_context.tbl_contact.ToList());
        }
        public IActionResult MarkAsResponded(int id)
        {
            var customer = _context.tbl_contact.FirstOrDefault(c => c.c_id == id);
            if (customer != null)
            {
                customer.ResponseStatus = true; // Response diya gaya hai
                _context.SaveChanges();
            }
            return RedirectToAction("showcontact"); // Jahan list show ho rahi hai wahan redirect karein
        }

    }
}
