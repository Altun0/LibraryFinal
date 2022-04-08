using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutubhane.Models.Entity;
namespace MvcKutubhane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUBHANEEntities db = new DBKUTUBHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEQORIs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEQORI p)
        {
            db.TBLKATEQORIs.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEQORIs.Find(id);
            db.TBLKATEQORIs.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEQORIs.Find(id);
            return View("KategoriGetir",ktg);
        }
        public ActionResult KategoriGuncelle(TBLKATEQORI p)
        {
            var ktg = db.TBLKATEQORIs.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}