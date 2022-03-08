using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCOkulSite.Models.Entity
{
    public class Baglanti
    {
        public static MVCOkulEntities db = new MVCOkulEntities();
        public  string Islem { get; set; }
    }
}