using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeChoreMapper.Controllers
{
    public class BaseController : Controller
    {
        public bool IsLogged()
        {
            if (Session["Username"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void LogUserIn(string username, string homename)
        {
            Session["Username"] = username;
            Session["Homename"] = homename;
        }

        public void LogUserOut()
        {
            Session.Abandon();
        }
    }
}