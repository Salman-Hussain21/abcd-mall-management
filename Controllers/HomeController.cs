using ABC_mall;
using Ecom_Store.Models;
using Ecom_Store.SqlContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Diagnostics;

namespace Ecom_Store.Controllers
{
	public class HomeController : Controller
	{
        sqlcontext sc;
        IWebHostEnvironment env;
        SendMailService sms;

        public HomeController(sqlcontext sc1, SendMailService sms1)
        {
            this.sc = sc1;
            this.sms = sms1;


        }
        public IActionResult Index()
		{
			return View();
		}
		public IActionResult About()
		{
			return View();
		}public IActionResult Contact()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Contact(Contactmodel ContactModel)
		{
			sc.ContactTable.Add(ContactModel);
			sc.SaveChanges();
			ModelState.Clear();
			ViewBag.success = "Message Sent Successfully";
			return View();
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Register(RegisterModel RegisterModel)
		{
			sc.RegisterModel.Add(RegisterModel);
			sc.SaveChanges();
			ModelState.Clear();
            ViewBag.RegisterSucced = "Message Sent Successfully";
            sms.sendmessage(RegisterModel.UserEmail);
            return View();
		}
		public IActionResult login()
		{
			return View();
		}
        [HttpPost]
        public IActionResult login(RegisterModel rm)
        {

            
               

                    var user = sc.RegisterModel.Where(x => x.UserEmail == rm.UserEmail
                 && x.UserPassword == rm.UserPassword).FirstOrDefault();
                if (user != null)
                {
                    var rp=Convert.ToString(user.Role);
                    HttpContext.Session.SetString("userSession", user.UserEmail);
                    HttpContext.Session.SetInt32("userRole", user.Role);
                    HttpContext.Session.SetInt32("userid", user.id);

                    var useremail = HttpContext.Session.GetString("userSession");
                    var userId = HttpContext.Session.GetInt32("userid");

                    if (user.Role == 1)
                    {
                        ViewBag.user = useremail;
                    sms.sendmessage(user.UserEmail);
                    return RedirectToAction("FetchContactData","Admin");
                        //return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        //return RedirectToAction("Index", "User");
                        ViewBag.userid = userId;
                        ViewBag.user = useremail;
                    sms.sendmessage(user.UserEmail);
                    return RedirectToAction("FetchContactData", "Admin");
                    }
                }
                else
                {
                    ViewBag.errormessage = "Email or Password Incorrect";
                    return View();
                }
            
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
           
            return RedirectToAction("login", "Home");

        }
        public IActionResult ProductPage()
        {
            return View(sc.ProductModel.ToList());
        }




    }
}
