using Skynet_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skynet_web.Controllers
{
    public class LoginController : Controller
    {
        NhadatDataContext data = new NhadatDataContext();
        // GET: Login
        public ActionResult Login()
        {

       
       
            return View();


        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Taikhoan objUser)
        {
            if (ModelState.IsValid)
            {
                using (NhadatDataContext db = new NhadatDataContext())
                {
                    var obj = db.Taikhoans.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.IDTaiKhoan.ToString();
                        Session["UserName"] = obj.Username.ToString();
                        return RedirectToAction("Index", "Quanly");


                    }
                }
            }
            ViewData["Error"] = "Sai mật khẩu hoặc Tên đăng nhập";
            return View(objUser);
        }


        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
