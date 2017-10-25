using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WittenBnb;

namespace WittenBnb.Controllers
{
    public class RoomController : Controller
    {
        // GET: Different rooms for actions of the same name
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Farmhouse()
        {
            return View();
        }
        public ActionResult Modern()
        {
            return View();
        }
        public ActionResult Minimalistic()
        {
            return View();
        }
        public ActionResult Victorian()
        {
            return View();
        }
    }
}