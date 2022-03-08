using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOkulSite.Models.Entity;

namespace MVCOkulSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult AnaSayfa()
        {
            var dersliste = Baglanti.db.Dersler.ToList();
            return View(dersliste);
        }


        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(Dersler d)
        {
            Baglanti.db.Dersler.Add(d);
            Baglanti.db.SaveChanges();
            return View();
        }
        public ActionResult DersSil(byte id)
        {
            var x = Baglanti.db.Dersler.Find(id);
            Baglanti.db.Dersler.Remove(x);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSayfa");
        }
        public ActionResult DersGuncelle(byte id)
        {
            var ders = Baglanti.db.Dersler.Find(id);
            return View("DersGuncelle", ders);
        }
        public ActionResult Guncelle(Dersler d)
        {
            var x = Baglanti.db.Dersler.Find(d.DersID);
            x.DersAd = d.DersAd;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSayfa");
        }
    }
}
