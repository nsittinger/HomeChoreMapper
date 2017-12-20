using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeChoreMapper.DAL;
using HomeChoreMapper.Models;
using HomeChoreMapper.Models.Data;
using HomeChoreMapper.Crypto;

namespace HomeChoreMapper.Controllers
{
    public class HomeController : BaseController
    {
        public readonly IUserDal userDal;
        public readonly IHomeDal homeDal;

        public HomeController(IUserDal userDal, IHomeDal homeDal)
        {
            this.userDal = userDal;
            this.homeDal = homeDal;
        }

        public ActionResult Index()
        {
            LogInViewModel model = new LogInViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LogInViewModel newUser)
        {
            if(ModelState.IsValid)
            {
                Hashing hashing = new Hashing();

                User userInDB = userDal.GetUser(newUser.Username);

                //Session["Username"] = userInDB.Username;
                //Session["Homename"] = userInDB.Homename;

                if (userInDB.Username == null)
                {
                    ModelState.AddModelError("invalid login", "The username or password combination is not valid");
                    return View(newUser);
                }

                bool validPassword = hashing.VerifyPasswordMatch(userInDB.Password, newUser.Password, userInDB.Salt);

                if (validPassword)
                {
                    base.LogUserIn(userInDB.Username, userInDB.Homename);
                    return RedirectToAction("MainHome", "Main");
                }
                else
                {
                    ModelState.AddModelError("invalid login", "The username or password combination is not valid");
                    return View(newUser);
                }
            }
            else
            {
                ModelState.AddModelError("invalid login", "The username or password combination is not valid");
                return View(newUser);
            }
        }

        [HttpGet]
        public ActionResult RegisterHome()
        {
            Home home = new Home();
            return View("RegisterHome", home);
        }

        [HttpPost]
        public ActionResult RegisterHome(Home home)
        {
            if (ModelState.IsValid)
            {
                if (home.Homename == null)
                {
                    return View(home);
                }

                Home newHome = new Home
                {
                    Homename = home.Homename,
                };

                bool success = homeDal.RegisterHome(newHome);
                if(success)
                {
                    TempData["successMessage"] = "You successfully added a home!";
                    return View("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "This homename is unavailable";
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            NewUserViewModel model = new NewUserViewModel();
            return View("RegisterUser", model);
        }

        [HttpPost]
        public ActionResult RegisterUser(NewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == null || model.Password == null)
                {
                    return View(model);
                }

                Hashing hashing = new Hashing();
                string hashedPassword = hashing.HashPassword(model.Password);
                string salt = hashing.SaltValue;

                User newUser = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Homename = model.Homename,
                    Password = hashedPassword,
                    Salt = salt,
                };

                bool success = userDal.CreateUser(newUser);

                if (success)
                {
                    TempData["successMessage"] = "You successfully added a home!";
                    return View("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "This homename is unavailable";
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            base.LogUserOut();
            return RedirectToAction("Index");
        }
    }
}