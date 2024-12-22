
using Ecom_Store.Models;
using Ecom_Store.SecondaryModels;
using Ecom_Store.SqlContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecom_Store.Controllers
{
    public class AdminController : Controller
    {
        sqlcontext sc;
        IWebHostEnvironment env;
        public AdminController(sqlcontext sc1,IWebHostEnvironment env1)
        {
            this.sc = sc1;
            this.env = env1;
        }

        public IActionResult FetchContactData(Contactmodel ContactModel)
        {

            var userdetail = HttpContext.Session.GetString("userSession");
            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {
                    return View(sc.ContactTable.ToList());

                }
                else
                {
                    return RedirectToAction("Index", "User");


                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }



        }
        public IActionResult ContactDetails(int Id)
        {

            var userdetail = HttpContext.Session.GetString("userSession");
            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {
                    
                    return View(sc.ContactTable.Find(Id));


                }
                else
                {
                    return RedirectToAction("Index", "User");


                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        public IActionResult ContactEdit(int Id)
        {

            var userdetail = HttpContext.Session.GetString("userSession");
            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    return View(sc.ContactTable.Find(Id));



                }
                else
                {
                    return RedirectToAction("Index", "User");


                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
        }
        [HttpPost]
        public IActionResult ContactEdit(Contactmodel ContactModel)
        {
            var user = sc.ContactTable.Find(ContactModel.Id);
            user.Name = ContactModel.Name;
            user.Email = ContactModel.Email;
            
            user.Message = ContactModel.Message;
            sc.SaveChanges();
            return RedirectToAction("FetchContactData");
        }
        public IActionResult ContactDelete(int id)
        {
            

            var userdetail = HttpContext.Session.GetString("userSession");
            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    var usersdata = sc.ContactTable.Find(id);
                    sc.Remove(usersdata);
                    sc.SaveChanges();
                    return RedirectToAction("FetchContactData");



                }
                else
                {
                    return RedirectToAction("Index", "User");


                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        public IActionResult AddProducts()
        {

            var userdetail = HttpContext.Session.GetString("userSession");
            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {
    
                    return View();




                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        [HttpPost]
        public IActionResult AddProducts(ImageModel IM)
        {
            String filename = "";
            String uploadFolder = Path.Combine(env.WebRootPath, "ProductImages");
            filename = Guid.NewGuid().ToString() + "_" + IM.ProductPhoto.FileName;
            String mergevalue = Path.Combine(uploadFolder, filename);
            IM.ProductPhoto.CopyTo(new FileStream(mergevalue, FileMode.Create));
            ProductModel pmModel = new ProductModel()
            {
                id = IM.id,
                ProductName = IM.ProductName,
                ProductDescription = IM.ProductDescription,
                ProductPrice = IM.ProductPrice,
                ProductQuantity = IM.ProductQuantity,
                ProductImage = filename
            };
            sc.ProductModel.Add(pmModel);
            sc.SaveChanges();
            ModelState.Clear();
            ViewBag.success = "Product has been added";
            return View();

        }
       
        
        public IActionResult FetchProducts(ProductModel PMS)
        {

            var userdetail = HttpContext.Session.GetString("userSession");
            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    return View(sc.ProductModel.ToList());




                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
        }
        public IActionResult EditProducts(int Id)
        {

            var userdetail = HttpContext.Session.GetString("userSession");
            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    return View(sc.ProductModel.Find(Id));





                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        [HttpPost]
        public IActionResult EditProducts(ImageModel IM)
        {
            String filename = "";
            String uploadFolder = Path.Combine(env.WebRootPath, "ProductImages");
            filename = Guid.NewGuid().ToString() + "_" + IM.ProductPhoto.FileName;
            String mergevalue = Path.Combine(uploadFolder, filename);
            IM.ProductPhoto.CopyTo(new FileStream(mergevalue, FileMode.Create));
             
                var user = sc.ProductModel.Find(IM.id);
                user.ProductName = IM.ProductName;
                user.ProductDescription = IM.ProductDescription;
                user.ProductPrice = IM.ProductPrice;
                user.ProductQuantity = IM.ProductQuantity;
                user.ProductImage = filename;
                          
            sc.SaveChanges();
            return RedirectToAction("FetchProducts");
        }
        public IActionResult DeleteProducts(int id)
        {
            
            var userdetail = HttpContext.Session.GetString("userSession");
            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    var usersdata = sc.ProductModel.Find(id);
                    sc.Remove(usersdata);
                    sc.SaveChanges();
                    return RedirectToAction("FetchProducts");





                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        public IActionResult ProductDetails(int Id)
        {

            var userdetail = HttpContext.Session.GetString("userSession");
            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                  return View(sc.ContactTable.Find(Id));





                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        public IActionResult AddShops()
        {

            var userdetail = HttpContext.Session.GetString("userSession");
            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    return View();




                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

           


        }
        [HttpPost]
        public IActionResult AddShops(Shop_ImgModel SHM)
        {
            String filename = "";
            String uploadFolder = Path.Combine(env.WebRootPath, "ShopsLogo");
            filename = Guid.NewGuid().ToString() + "_" + SHM.ShopLogo.FileName;
            String mergevalue = Path.Combine(uploadFolder, filename);
            SHM.ShopLogo.CopyTo(new FileStream(mergevalue, FileMode.Create));
            ShopsModel SHPM = new ShopsModel()
            {
                id = SHM.id,
                ShopName = SHM.ShopName,
                ShopLogo = filename
            };
            sc.ShopsModel.Add(SHPM);
            sc.SaveChanges();
            ModelState.Clear();
            ViewBag.success = "Shop has been added";
            return View();

        }
        public IActionResult FetchShops(ProductModel PMS)
        {

            var userdetail = HttpContext.Session.GetString("userSession");
            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    return View(sc.ShopsModel.ToList());



                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            

        }
        public IActionResult DeleteShops(int id)
        {
            var usersdata = sc.ShopsModel.Find(id);
            sc.Remove(usersdata);
            sc.SaveChanges();
            return RedirectToAction("FetchShops");
        }
        public IActionResult AddFoodCourts()
        {
            var userdetail = HttpContext.Session.GetString("userSession");

            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    return View();



                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

            


        }
        [HttpPost]
        public IActionResult AddFoodCourts(FoodCourt_ImgModel FCM)
        {
            String filename = "";
            String uploadFolder = Path.Combine(env.WebRootPath, "FoodCourtsLogo");
            filename = Guid.NewGuid().ToString() + "_" + FCM.FoodCourtLogo.FileName;
            String mergevalue = Path.Combine(uploadFolder, filename);
            FCM.FoodCourtLogo.CopyTo(new FileStream(mergevalue, FileMode.Create));
            FoodCourtModel FCPM = new FoodCourtModel()
            {
                id = FCM.id,
                FoodCourtName = FCM.FoodCourtName,
                FoodCourtLogo = filename
            };
            sc.FoodCourtModel.Add(FCPM);
            sc.SaveChanges();
            ModelState.Clear();
            ViewBag.success = "Shop has been added";
            return View();

        }
        public IActionResult FetcFoodCourts(ProductModel PMS)
        {

            var userdetail = HttpContext.Session.GetString("userSession");

            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    return View(sc.FoodCourtModel.ToList());


                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }
            

        }
        public IActionResult DeleteFoodCourts(int id)
        {
            var usersdata = sc.FoodCourtModel.Find(id);
            sc.Remove(usersdata);
            sc.SaveChanges();
            return RedirectToAction("FetcFoodCourts");
        }
        public IActionResult AddCinema()
        {

            var userdetail = HttpContext.Session.GetString("userSession");

            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    return View();


                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

           


        }
        [HttpPost]
        public IActionResult AddCinema(Cinmea_ImgModel CIM)
        {
            String filename = "";
            String uploadFolder = Path.Combine(env.WebRootPath, "CinemasLogo");
            filename = Guid.NewGuid().ToString() + "_" + CIM.CinemaLogo.FileName;
            String mergevalue = Path.Combine(uploadFolder, filename);
            CIM.CinemaLogo.CopyTo(new FileStream(mergevalue, FileMode.Create));
            CinemaModel SHPM = new CinemaModel()
            {
                id = CIM.id,
                CinemaName = CIM.CinemaName,
                CinemaDesc = CIM.CinemaDesc,
                CinemaSeats = CIM.CinemaSeats,  

                CinemaLogo = filename
            };
            sc.CinemaModel.Add(SHPM);
            sc.SaveChanges();
            ModelState.Clear();
            ViewBag.success = "Shop has been added";


            return View();

            }
        public IActionResult FetchCinema(CinemaModel CIM)
        {
            var userdetail = HttpContext.Session.GetString("userSession");

            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    return View(sc.CinemaModel.ToList());



                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        public IActionResult EditCinema(int id)
        {

            var userdetail = HttpContext.Session.GetString("userSession");

            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    var record = sc.CinemaModel.Find(id);
                    Cinmea_ImgModel sm = new Cinmea_ImgModel()
                    {
                        CinemaName = record.CinemaName,
                        CinemaDesc = record.CinemaDesc,
                        CinemaSeats = record.CinemaSeats


                    };
                    return View(sm);



                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

            
        }

        [HttpPost]
        public IActionResult EditCinema(Cinmea_ImgModel CIM, int id)
        {
            var record = sc.CinemaModel.Find(id);
            if (record != null)
            {
                String filename = "";
                String uploadFolder = Path.Combine(env.WebRootPath, "CinemasLogo");
                filename = Guid.NewGuid().ToString() + "_" + CIM.CinemaLogo.FileName;
                String mergevalue = Path.Combine(uploadFolder, filename);
                CIM.CinemaLogo.CopyTo(new FileStream(mergevalue, FileMode.Create));

                record.CinemaName = CIM.CinemaName;
                record.CinemaDesc = CIM.CinemaDesc;
                record.CinemaSeats = CIM.CinemaSeats;
                record.CinemaLogo = filename;


                sc.SaveChanges();
                ModelState.Clear();

                return View();
            }
            else
            {
                return View();
            }
        }
        public IActionResult DeleteCinema(int id)
        {
            var usersdata = sc.CinemaModel.Find(id);
            sc.Remove(usersdata);
            sc.SaveChanges();
            return RedirectToAction("FetchCinema");
        }
        public IActionResult EditShop(int id)
        {
            var userdetail = HttpContext.Session.GetString("userSession");

            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    var record = sc.ShopsModel.Find(id);
                    Shop_ImgModel sm = new Shop_ImgModel()
                    {
                        ShopName = record.ShopName,


                    };
                    return View(sm);



                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

            
        }

        [HttpPost]
        public IActionResult EditShop(Shop_ImgModel sm, int id)
        {
            var record = sc.ShopsModel.Find(id);
            if (record != null)
            {
                String filename = "";
                String uploadFolder = Path.Combine(env.WebRootPath, "ShopsLogo");
                filename = Guid.NewGuid().ToString() + "_" + sm.ShopLogo.FileName;
                String mergevalue = Path.Combine(uploadFolder, filename);
                sm.ShopLogo.CopyTo(new FileStream(mergevalue, FileMode.Create));

                record.ShopLogo = filename;
                record.ShopName = sm.ShopName;

                sc.SaveChanges();
                ModelState.Clear();

                return View();
            }
            else
            {
                return View();
            }
        }
        public IActionResult AddMovies()
        {
            var userdetail = HttpContext.Session.GetString("userSession");

            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    var cinemas = sc.CinemaModel.ToList();
                    ViewBag.Cin = cinemas;
                    return View();


                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

           

           

            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMovies(Movies_ImgModel MIM)
        {

            String filename = "";
            String uploadFolder = Path.Combine(env.WebRootPath, "MoviesPicture");
            filename = Guid.NewGuid().ToString() + "_" + MIM.MoviePicture.FileName;
            String mergevalue = Path.Combine(uploadFolder, filename);
            MIM.MoviePicture.CopyTo(new FileStream(mergevalue, FileMode.Create));
            MoviesModel SHPM = new MoviesModel()
            {
                id = MIM.id,
                Movies_Name = MIM.Movies_Name,
                Movies_Desc = MIM.Movies_Desc,
                StartTime = MIM.StartTime,
                EndTime = MIM.EndTime,
                ScreeningDate =MIM.ScreeningDate,
                Cinema_ID = MIM.Cinema_ID,


                MoviePicture = filename
            };
            sc.MoviesModel.Add(SHPM);
            sc.SaveChanges();
            ModelState.Clear();
            


            return View();

           
            
           
        }
    
        public IActionResult FetchMovies(MoviesModel MMmodel)
        {
            var userdetail = HttpContext.Session.GetString("userSession");

            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    return View(sc.MoviesModel.Include(x => x.CinemaName).ToList());


                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

        }
        public IActionResult EditMovies(int id)
        {
            var userdetail = HttpContext.Session.GetString("userSession");

            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    var cinemas = sc.CinemaModel.ToList();
                    ViewBag.Cin = cinemas;
                    var record = sc.MoviesModel.Find(id);
                    Movies_ImgModel MIMS = new Movies_ImgModel()
                    {
                        Movies_Name = record.Movies_Name,
                        Movies_Desc = record.Movies_Desc,
                        StartTime = record.StartTime,
                        EndTime = record.EndTime,
                        ScreeningDate = record.ScreeningDate,
                        Cinema_ID = record.Cinema_ID
                    };
                    return View(MIMS);


                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }


           

        }
        [HttpPost]
        public IActionResult EditMovies(Movies_ImgModel MIMSG , int id)
        {
            var record = sc.MoviesModel.Find(id);

            if (record != null)
            {

                String filename = "";
                String uploadFolder = Path.Combine(env.WebRootPath, "MoviesPicture");
                filename = Guid.NewGuid().ToString() + "_" + MIMSG.MoviePicture.FileName;
                String mergevalue = Path.Combine(uploadFolder, filename);
                MIMSG.MoviePicture.CopyTo(new FileStream(mergevalue, FileMode.Create));

                record.Movies_Name = MIMSG.Movies_Name;
                record.Movies_Desc = MIMSG.Movies_Desc;
                record.StartTime = MIMSG.StartTime;
                record.EndTime = MIMSG.EndTime;
                record.ScreeningDate = MIMSG.ScreeningDate;
                record.Cinema_ID = MIMSG.Cinema_ID;
                record.MoviePicture = filename;

                sc.SaveChanges();
                ModelState.Clear();
                return View();
            }
            else
            {
                return View();
            }
        }
        public IActionResult DeleteMovies(int id)
        {
            var usersdata = sc.MoviesModel.Find(id);
            sc.Remove(usersdata);
            sc.SaveChanges();
            return RedirectToAction("FetchMovies");
        }
        public IActionResult Editfoodcourt(int id)
        {
            var userdetail = HttpContext.Session.GetString("userSession");

            if (userdetail != "" && userdetail != null)
            {

                ViewBag.user = userdetail;
                var userRole = HttpContext.Session.GetInt32("userRole");


                if (userRole != 0)
                {

                    var record = sc.FoodCourtModel.Find(id);
                    FoodCourt_ImgModel sm = new FoodCourt_ImgModel()
                    {
                        FoodCourtName = record.FoodCourtName,


                    };
                    return View(sm);


                }
                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("login", "Home");
            }

            
        }

        [HttpPost]
        public IActionResult Editfoodcourt(FoodCourt_ImgModel fm, int id)
        {
            var record = sc.FoodCourtModel.Find(id);
            if (record != null)
            {
                String filename = "";
                String uploadFolder = Path.Combine(env.WebRootPath, "FoodCourtsLogo");
                filename = Guid.NewGuid().ToString() + "_" + fm.FoodCourtLogo.FileName;
                String mergevalue = Path.Combine(uploadFolder, filename);
                fm.FoodCourtLogo.CopyTo(new FileStream(mergevalue, FileMode.Create));

                record.FoodCourtLogo = filename;
                record.FoodCourtName = fm.FoodCourtName;

                sc.SaveChanges();
                ModelState.Clear();

                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
