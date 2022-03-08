using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOkulSite.Models.Entity;

namespace MVCOkulSite.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        public ActionResult AnaSayfa()
        {
            //var ogrenciler = (from x in Baglanti.db.Ogrenciler
            //                  select new
            //                  {
            //                      x.OgrID,
            //                      x.OgrAd,
            //                      x.OgrSoyad,
            //                      x.OgrCinsiyet,
            //                      x.Kulupler.KulupAd
            //                  }).ToList();
            var ogrenciler = Baglanti.db.Ogrenciler.ToList();
            return View(ogrenciler);
        }


        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from x in Baglanti.db.Kulupler.ToList()
                                             select new
                                             SelectListItem
                                             { Text = x.KulupAd, Value = x.KulupID.ToString() }
                                             ).ToList();
            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(Ogrenciler o)
        {
            var klp = Baglanti.db.Kulupler.Where(m => m.KulupID == o.Kulupler.KulupID).FirstOrDefault();
            o.Kulupler = klp;
            Baglanti.db.Ogrenciler.Add(o);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSayfa");
        }
        public ActionResult OgrenciSil(byte id)
        {
            var x = Baglanti.db.Ogrenciler.Find(id);
            Baglanti.db.Ogrenciler.Remove(x);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSayfa");
        }
        public ActionResult OgrenciGuncelle(byte id)
        {
            List<SelectListItem> degerler = (from x in Baglanti.db.Kulupler.ToList()
                                             select new
                                             SelectListItem
                                             { Text = x.KulupAd, Value = x.KulupID.ToString() }
                                             ).ToList();
            ViewBag.dgr = degerler;

            var ogr = Baglanti.db.Ogrenciler.Find(id);
            return View("OgrenciGuncelle", ogr);
        }
        public ActionResult Guncelle(Ogrenciler g)
        {
            var klp = Baglanti.db.Kulupler.Where(m => m.KulupID == g.Kulupler.KulupID).FirstOrDefault();
            g.Kulupler = klp;
            var x = Baglanti.db.Ogrenciler.Find(g.OgrID);
            x.OgrAd = g.OgrAd;
            x.OgrSoyad = g.OgrSoyad;
            x.OgrFotograf = g.OgrFotograf;
            x.OgrCinsiyet = g.OgrCinsiyet;
            x.OgrKulup = g.OgrKulup;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSayfa");
        }
    }

}