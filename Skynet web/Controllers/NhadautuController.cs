using Skynet_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skynet_web.Controllers
{
    public class NhadautuController : Controller
    {
        NhadatDataContext data = new NhadatDataContext();
        // GET: Nhadautu
        public ActionResult Index()
        {
            var all_sach = from s in data.Nhadautus select s;
            return View(all_sach);
        }
    }
}