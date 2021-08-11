using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class ÜrünController : Controller
    {
        // GET: Ürün
        DBMvcStokEntities db = new DBMvcStokEntities();
        public ActionResult Index(string p)
        {
            // var urunler = db.TBLURUNLER.Where(x=>x.DURUM==true).ToList();
            var urunler = db.TBLURUNLER.Where(x=>x.DURUM==true);
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.AD.Contains(p)&& x.DURUM==true);
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniÜrün()
        {
            List<SelectListItem> ktg = (from x in db.TBLKATEGORİ.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.AD,
                                            Value = x.İD.ToString()
                                        }).ToList();

            ViewBag.drop = ktg;
            return View();
        }
        [HttpPost]
        public ActionResult YeniÜrün(TBLURUNLER t)
        {
            var ktgr = db.TBLKATEGORİ.Where(x => x.İD == t.TBLKATEGORİ.İD).FirstOrDefault();
            t.TBLKATEGORİ = ktgr;
            db.TBLURUNLER.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜrünGetir(int id)
        {
            List<SelectListItem> kat = (from x in db.TBLKATEGORİ.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.AD,
                                            Value = x.İD.ToString()
                                        }).ToList();


            var ktgr = db.TBLURUNLER.Find(id);
            ViewBag.urunkategori = kat;
            return View("ÜrünGetir", ktgr);
        }
        public ActionResult UrunGuncelle(TBLURUNLER p)
        {
            var urun = db.TBLURUNLER.Find(p.İD);
            urun.MARKA = p.MARKA;
            urun.SATISFIYAT = p.SATISFIYAT;
            urun.STOK = p.STOK;
            urun.ALISFIYAT = p.ALISFIYAT;
            urun.AD = p.AD;
            var ktg = db.TBLKATEGORİ.Where(x=>x.İD==p.TBLKATEGORİ.İD).FirstOrDefault();
            urun.KATEGORİ = ktg.İD;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult ÜrünSil(TBLURUNLER h)
        {
            var urunbul = db.TBLURUNLER.Find(h.İD);
            urunbul.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}