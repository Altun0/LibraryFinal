using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutubhane.Models.Entity;
using MvcKutubhane.Models.Siniflarim;
namespace MvcKutubhane.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBKUTUBHANEEntities db = new DBKUTUBHANEEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLKITAPs.ToList();
            cs.Deger2 = db.TBLHAKKIMIZDAs.ToList();
            //var degerler = db.TBLKITAPs.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLILETISIM t)
        {
            db.TBLILETISIMs.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}