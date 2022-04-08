using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutubhane.Models.Entity;
namespace MvcKutubhane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUBHANEEntities db = new DBKUTUBHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLYAZARs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        public ActionResult YazarEkle(TBLYAZAR p)
        {
            db.TBLYAZARs.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBLYAZARs.Find(id);
            db.TBLYAZARs.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBLYAZARs.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TBLYAZAR p)
        {
            var yzr = db.TBLYAZARs.Find(p.ID);
            yzr.AD = p.AD;
            yzr.SOYAD = p.SOYAD;
            yzr.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}