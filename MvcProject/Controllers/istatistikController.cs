using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Categories.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = c.Headings.Count(x => x.CategoryID == 9).ToString();
            ViewBag.d2 = deger2;

            var deger3 = c.Writers.Count(x => x.WriterName.Contains("a")).ToString();
            ViewBag.d3 = deger3;

            //var deger4 = c.Categories.Where(u => u.CategoryID == (c.Headings.GroupBy(x => x.CategoryID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.CategoryName).FirstOrDefault();
            //ViewBag.d4 = deger4;
            var deger4 = c.Categories.OrderByDescending(x => x.Headings.Count()).FirstOrDefault().CategoryName.ToString();
            ViewBag.d4 = deger4;

            var deger5 = c.Categories.Count(x => x.CategoryStatus ==true);
            var deger6 = c.Categories.Count(x => x.CategoryStatus == false);
            var sonuc = deger5 - deger6;
            ViewBag.d5 = sonuc;

            return View();

        }
    }
}