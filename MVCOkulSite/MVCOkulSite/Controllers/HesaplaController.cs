using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOkulSite.Controllers
{
    public class HesaplaController : Controller
    {
        // GET: Hesapla
        public ActionResult AnaSayfa(int s1 = 0, int s2 = 0)
        {
            int sonuc = s1 + s2;
            ViewBag.snc = sonuc;
            return View();

        }
    }
}