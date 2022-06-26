using Skynet_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Skynet_web.Controllers
{
    public class QuanlyController : Controller
    {
     NhadatDataContext data = new NhadatDataContext();
        // GET: Quanly
        public ActionResult Index()
        {
            var all_sach = from s in data.Houses select s;
            return View(all_sach);
           
        }
        public ActionResult Detail(int id)
        {
            var D_sach = data.Houses.Where(m => m.IDHouse == id).First();
            return View(D_sach);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, House s)
        {
            //var E_makh = collection["makh"];
            var E_Code = collection["Tennhadat"];
            var E_IDDuAn = collection["GiaBan"];
            var E_Name = collection["Hinh"];
            var E_Sumary = collection["Tenduan"];
            var E_Views = collection["Sophong"];
            var E_IDMap = collection["Gioithieu"];
            var E_BedRoom = collection["Dientich"];
            var E_Area = collection["Vitri"];
            var E_Price = collection["Giathue"];
            var E_State = collection["idduan"];
            var E_idtk = collection["idtaikhoan"];

            if (string.IsNullOrEmpty(E_Code))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                //s.makh = int.Parse(E_makh.ToString());
                s.Tennhadat = E_Code.ToString();
                s.GiaBan = int.Parse(E_IDDuAn);
                s.Hinh = E_Name.ToString();
                s.Tenduan = E_Sumary.ToString();
                s.Sophong = int.Parse(E_Views);
                s.Gioithieu = E_IDMap.ToString();
                s.Dientich = int.Parse(E_BedRoom);
                s.Vitri = E_Area;
                s.Giathue = int.Parse(E_Price.ToString());
                s.idduan = byte.Parse(E_State) ;
                s.idtaikhoan = int.Parse(E_idtk);

                data.Houses.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index", "Quanly");
            }
            return this.Create();
        }
        public ActionResult Edit(int id)
        {
           
            var E_category = data.Houses.First(m => m.IDHouse == id);
            return View(E_category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection, House b)
        {
           
            var E_sach = data.Houses.FirstOrDefault(m => m.IDHouse == id);

            var E_Code = collection["Tennhadat"];
            var E_IDDuAn = collection["GiaBan"];
            var E_Name = collection["Hinh"];
            var E_Sumary = collection["Tenduan"];
            var E_Views = collection["Sophong"];
            var E_IDMap = collection["Gioithieu"];
            var E_BedRoom = collection["Dientich"];
            var E_Area = collection["Vitri"];
            var E_Price = collection["Giathue"];
            var E_State = collection["idduan"];
            var E_idtk = collection["idtaikhoan"];

            if (string.IsNullOrEmpty(E_Code))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {

                //s.makh = int.Parse(E_makh.ToString());
                b.Tennhadat = E_Code.ToString();
                b.GiaBan = int.Parse(E_IDDuAn);
                b.Hinh = E_Name.ToString();
                b.Tenduan = E_Sumary.ToString();
                b.Sophong = int.Parse(E_Views);
                b.Gioithieu = E_IDMap.ToString();
                b.Dientich = int.Parse(E_BedRoom);
                b.Vitri = E_Area;
                b.Giathue = int.Parse(E_Price.ToString());
                b.idduan = byte.Parse(E_State);
                b.idtaikhoan = int.Parse(E_idtk);
                UpdateModel(E_sach);
                data.SubmitChanges();
            }
            return RedirectToAction("Index", "Quanly");
        }
        public ActionResult Delete(int id)
        {
            var D_sach = data.Houses.First(m => m.IDHouse == id);
            return View(D_sach);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sach = data.Houses.Where(m => m.IDHouse == id).First();
            data.Houses.DeleteOnSubmit(D_sach);
            data.SubmitChanges();
            return RedirectToAction("Index", "Quanly");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
    }
}