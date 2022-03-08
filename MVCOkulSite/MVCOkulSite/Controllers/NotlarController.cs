using MVCOkulSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOkulSite.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        public ActionResult AnaSayfa()
        {
            var notlar = Baglanti.db.Notlar.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniNot()
        {
            List<SelectListItem> degerler = (from x in Baglanti.db.Dersler.ToList()
                                             select new
                                             SelectListItem
                                             { Text = x.DersAd, Value = x.DersID.ToString() }
                                                 ).ToList();
            ViewBag.ders = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniNot(Notlar n)
        {
            //var drs = Baglanti.db.Dersler.Where(m => m.DersID == n.Dersler.DersID).FirstOrDefault();
            //n.Dersler = drs;
            Baglanti.db.Notlar.Add(n);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AnaSayfa");
        }
        public ActionResult NotGuncelle(byte id)
        {
            var not = Baglanti.db.Notlar.Find(id);
            return View("NotGuncelle", not);
        }

        [HttpPost]
        public ActionResult NotGuncelle(Baglanti model, Notlar n, int Sinav1 = 0, int Sinav2 = 0, int Sinav3 = 0, int Proje = 0)
        {
            if (model.Islem == "Hesapla")
            {
                int ortalama = (Sinav1 + Sinav2 + Sinav3 + Proje) / 4;
                ViewBag.ort = ortalama;
                if (ortalama >= 50)
                {
                    ViewBag.durum = "True";
                }
                else
                {
                    ViewBag.durum = "False";
                }
            }
            if (model.Islem == "Guncelle")
            {
                var snv = Baglanti.db.Notlar.Find(n.NotID);
                snv.Sinav1 = n.Sinav1;
                snv.Sinav2 = n.Sinav2;
                snv.Sinav3 = n.Sinav3;
                snv.Proje = n.Proje;
                snv.Ortalama = n.Ortalama;
                snv.Durum = n.Durum;
                Baglanti.db.SaveChanges();
                return RedirectToAction("AnaSayfa", "Notlar");
            }
            return View();
        }
    }
}