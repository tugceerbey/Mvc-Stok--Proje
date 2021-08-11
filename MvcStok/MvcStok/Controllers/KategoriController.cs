using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBMvcStokEntities db = new DBMvcStokEntities();
        public ActionResult Index()
        {
            var kategoriler = db.TBLKATEGORİ.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORİ p)
        {
            db.TBLKATEGORİ.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.TBLKATEGORİ.Find(id);
            db.TBLKATEGORİ.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORİ.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORİ k)
        {
            var ktg = db.TBLKATEGORİ.Find(k.İD);
            ktg.AD = k.AD;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}