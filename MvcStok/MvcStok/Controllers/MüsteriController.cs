using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class MüsteriController : Controller
    {
        // GET: Müsteri
        DBMvcStokEntities db = new DBMvcStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            var musteriliste = db.TBLMUSTERİ.Where(x=>x.DURUM==true).ToList().ToPagedList(sayfa,3);
            //var musteriliste = db.TBLMUSTERİ.ToList();
            return View(musteriliste);
        }
        [HttpGet]
        public ActionResult YeniMüsteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMüsteri(TBLMUSTERİ p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMüsteri");
            }
            p.DURUM = true;
            db.TBLMUSTERİ.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MüsteriSil(int id)
        {
            var musteribul = db.TBLMUSTERİ.Find(id);
            musteribul.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MüsteriGetir(int id)
        {
            var mstrgtr = db.TBLMUSTERİ.Find(id);
            return View("MüsteriGetir", mstrgtr);
        }
        public ActionResult MüsteriGüncelle(TBLMUSTERİ t)
        {
            var mus = db.TBLMUSTERİ.Find(t.İD);   //id olması gerekıyor yoksa hata gelır
            mus.AD = t.AD;
            mus.SOYAD = t.SOYAD;
            mus.SEHİR = t.SEHİR;
            mus.BAKIYE = t.BAKIYE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}