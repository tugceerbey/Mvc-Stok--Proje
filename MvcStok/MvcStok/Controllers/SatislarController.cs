using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        DBMvcStokEntities db = new DBMvcStokEntities();
        public ActionResult Index()
        {
            var satislar = db.TBLSATİS.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            //ürünler
            List<SelectListItem> urun = (from x in db.TBLURUNLER.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.AD,
                                             Value = x.İD.ToString()
                                         }).ToList();

            ViewBag.drop1 = urun;
            //personel
            List<SelectListItem> per = (from x in db.TBLPERSONEL.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.AD + " " + x.SOYAD,
                                            Value = x.İD.ToString()
                                        }).ToList();

            ViewBag.drop2 = per;

            //müsteriler
            List<SelectListItem> sts = (from x in db.TBLMUSTERİ.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.AD + " " + x.SOYAD,
                                            Value = x.İD.ToString()
                                        }).ToList();

            ViewBag.drop3 = sts;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATİS p)
        {
            var urun = db.TBLURUNLER.Where(x => x.İD == p.TBLURUNLER.İD).FirstOrDefault();
            var musteri = db.TBLMUSTERİ.Where(x => x.İD == p.TBLMUSTERİ.İD).FirstOrDefault();
            var personel = db.TBLPERSONEL.Where(x => x.İD == p.TBLPERSONEL.İD).FirstOrDefault();
            p.TBLURUNLER = urun;
            p.TBLMUSTERİ = musteri;
            p.TBLPERSONEL = personel;
            p.TARİH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLSATİS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}