using Skynet_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skynet_web.Controllers
{
    public class trangchuController : Controller
    {
        // GET: trangchu
        NhadatDataContext data = new NhadatDataContext();
        public ActionResult Index()
        {
            var all_sach = from s in data.Houses select s;
            return View(all_sach);
        }
    }
}