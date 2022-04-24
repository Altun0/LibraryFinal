using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutubhane.Models.Entity;
namespace MvcKutubhane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DBKUTUBHANEEntities db = new DBKUTUBHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKETs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET p)
        {
            db.TBLHAREKETs.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult OduncIade(TBLHAREKET p)
        {
            var odn = db.TBLHAREKETs.Find(p.ID);
            DateTime d1 = DateTime.Parse(odn.IADETARIH.ToString());

            ViewBag.dgr = d1;
            return View("OduncIade", odn);
        }
        public ActionResult OduncGuncelle(TBLHAREKET p)
        {
            var hrk = db.TBLHAREKETs.Find(p.ID);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}