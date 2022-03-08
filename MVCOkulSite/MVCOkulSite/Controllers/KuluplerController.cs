using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOkulSite.Models.Entity;
namespace MVCOkulSite.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        public ActionResult AnaSayfa()
        {
            var kulupliste = Baglanti.db.Kulupler.ToList();
            return View(kulupliste);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(Kulupler k)
        {
            Baglanti.db.Kulupler.Add(k);
            Baglanti.db.SaveChanges();
            return View();
        }
        public ActionResult KulupSil(byte id)
        {
            var x = Baglanti.db.Kulupler.Find(id);
            Baglanti.db.Kulupler.Remove(x);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSayfa");
        }

        public ActionResult KulupGuncelle(byte id)
        {
            var kulup = Baglanti.db.Kulupler.Find(id);
            return View("KulupGuncelle", kulup);
        }
        public ActionResult Guncelle(Kulupler p)
        {
            var klp = Baglanti.db.Kulupler.Find(p.KulupID);
            klp.KulupAd = p.KulupAd;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSayfa");
        }
    }
}