using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class GirisController : Controller
    {
        // GET: Giris
        DBMvcStokEntities db = new DBMvcStokEntities();
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(TBLADMIN p)
        {
            var bilgiler = db.TBLADMIN.FirstOrDefault(x=>x.KULLANICI==p.KULLANICI && x.SİFRE==p.SİFRE);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI, false);
                return RedirectToAction("Index","Müsteri");
            }
            else
            {
                return View();
            }
        }
    }
}