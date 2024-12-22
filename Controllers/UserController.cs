using Ecom_Store.Models;
using Ecom_Store.SqlContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecom_Store.Controllers
{
    public class UserController : Controller
    {
        sqlcontext sc;
        IWebHostEnvironment env;
        public UserController(sqlcontext sc1, IWebHostEnvironment env1)
        {
            this.sc = sc1;
            this.env = env1;
        }
        public IActionResult Index()
        {
            return View();
            //return View(sc.ShopsModel.ToList());
        }
        public IActionResult FindUS()
        {
            return View();
        }
        public IActionResult PhotoGallery()
        {
            return View();
        }
        public IActionResult AboutUS()
        {
            return View();
        }
        public IActionResult Shopping()
        {
            return View(sc.ShopsModel.ToList());
        }
        public IActionResult Dinning()
        {
            return View(sc.FoodCourtModel.ToList());
        }
        public IActionResult Cinema()
        {
            return View(sc.CinemaModel.ToList());
        }
        public IActionResult Movies()
        {
            return View(sc.MoviesModel.ToList());

        }
        public IActionResult MoviesDetails(int id)
        {
            var movierecord = sc.MoviesModel.Find(id);
            if (movierecord != null && movierecord.Cinema_ID != null)
            {
                var cinemarecord = sc.CinemaModel.Find(movierecord.Cinema_ID);
                ViewBag.Cinema = cinemarecord.CinemaName;
                ViewBag.CinemaId = cinemarecord.id;
                ViewBag.MovieId = id;
                ViewBag.CinemaSeats = cinemarecord.CinemaSeats;
                // Proceed with your logic using cinemarecord
            }
            else
            {
                // Handle the case where movierecord or movierecord.Cinema_ID is null
                // You can log an error, throw an exception, or take appropriate action based on your application's requirements.
            }
            
            return View(movierecord);
        }

        [HttpPost]
        public IActionResult bookedseats(int movieid, int cinemaid, int seatid , string userEmail)
        {
            // Your existing logic here to check and book the seat
            var seatcheck = sc.BookedSeats.FirstOrDefault(x => x.MovieID == movieid && x.SeatId == seatid);

            if (seatcheck != null)
            {
                TempData["Status"] = "Already Booked";
            }
            else
            {
                BookedSeats seats = new BookedSeats()
                {
                    SeatId = seatid,
                    MovieID = movieid,
                    Status = "Reserved",
                    CinemaId = cinemaid,
                    UserEmail = userEmail
                };
                sc.BookedSeats.Add(seats);
                sc.SaveChanges();
               
                return RedirectToAction("Payment", "User", new { movieid = movieid, cinemaid = cinemaid, seatid = seatid });
            }

            // Return the same view with updated TempData["Status"]
            return RedirectToAction("Movies", "User");
        }
        public IActionResult payment()
        {
            TempData["Status"] = "Booked";
            return View();
        }


        public IActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Feedback(Contactmodel ContactModel)
        {
            sc.ContactTable.Add(ContactModel);
            sc.SaveChanges();
            ModelState.Clear();
            ViewBag.success = "Message Sent Successfully";
            return View();
        }
        

    }


}