using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeChoreMapper.DAL;
using HomeChoreMapper.Models;
using HomeChoreMapper.Models.Data;

namespace HomeChoreMapper.Controllers
{
    public class MainController : BaseController
    {
        public readonly IHomeUsersChoresDAL HUCdal;
        private readonly IHomeDal homeDal;
        private readonly IUserDal userDal;
        private readonly IChoreDal choreDal;

        public MainController(IHomeUsersChoresDAL HUCdal, IHomeDal homeDal, IUserDal userDal, IChoreDal choreDal)
        {
            this.HUCdal = HUCdal;
            this.homeDal = homeDal;
            this.userDal = userDal;
            this.choreDal = choreDal;
        }

        [HttpGet]
        public ActionResult MainHome()
        {
            List<HomesUsersChores> HUCList = new List<HomesUsersChores>();
            string username = (string)Session["Username"];
            string homename = (string)Session["Homename"];

            //HUCList = HUCdal.GetHUCList(username, homename);
            HUCList = HUCdal.GetHUCList(homename);
            return View(HUCList);
        }

        [HttpGet]
        public ActionResult AddCompletedChore()
        {
            string username = (string)Session["Username"];
            string homename = (string)Session["Homename"];

            int homeID = homeDal.GetHome(homename).HomeID;

            List<Chore> choreList = choreDal.GetChoreList(homeID);
            CompletedHUC HUC = new CompletedHUC();

            Session["ChoreList"] = choreList;
            return View(HUC);
        }

        [HttpPost]
        public ActionResult AddCompletedChore(CompletedHUC HUC)
        {
            if(ModelState.IsValid)
            {
                string username = (string)Session["Username"];
                string homename = (string)Session["Homename"];

                Home home = homeDal.GetHome(homename);
                User user = userDal.GetUser(username);
                Chore chore = choreDal.GetChore(HUC.Chorename);

                HomesUsersChores newHUC = new HomesUsersChores()
                {
                    HomeID = home.HomeID,
                    Homename = home.Homename,
                    UserID = user.UserID,
                    Username = user.Username,
                    ChoreID = chore.ChoreID,
                    Chorename = chore.Chorename,
                    DateCompleted = DateTime.Now,
                    Comments = HUC.Comments
                };

                bool choreSuccess = HUCdal.AddCompletedChoreSQL(newHUC);

                if (choreSuccess)
                {
                    TempData["successMessage"] = "You completed a chore!";
                    return RedirectToAction("MainHome", "Main");
                }
                else
                {
                    ViewBag.ErrorMessage = "Unsuccessful attempt to add chore";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Unsuccessful attempt to add chore";
                return View();
            }
        }
    }
}