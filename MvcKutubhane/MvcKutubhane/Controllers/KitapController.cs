using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutubhane.Models.Entity;
namespace MvcKutubhane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKUTUBHANEEntities db = new DBKUTUBHANEEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBLKITAPs select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.AD.Contains(p));
            }
           //var kitaplar = db.TBLKITAPs.ToList();
           return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEQORIs.ToList() select new SelectListItem { Text = i.AD, Value = i.ID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBLYAZARs.ToList() select new SelectListItem { Text = i.AD + ' '+ i.SOYAD, Value = i.ID.ToString() }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP p)
        {
            var ktg = db.TBLKATEQORIs.Where(k => k.ID == p.TBLKATEQORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZARs.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            p.TBLKATEQORI = ktg;
            p.TBLYAZAR = yzr;
            db.TBLKITAPs.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKITAPs.Find(id);
            db.TBLKITAPs.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TBLKITAPs.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKATEQORIs.ToList() select new SelectListItem { Text = i.AD, Value = i.ID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.TBLYAZARs.ToList() select new SelectListItem { Text = i.AD + ' ' + i.SOYAD, Value = i.ID.ToString() }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGuncelle(TBLKITAP p)
        {
            var kitap = db.TBLKITAPs.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYIL = p.BASIMYIL;
            kitap.SAYFA = p.SAYFA;
            kitap.YAYINEVI = p.YAYINEVI;
            var ktg = db.TBLKATEQORIs.Where(k => k.ID == p.TBLKATEQORI.ID).FirstOrDefault();
            var yzr = db.TBLYAZARs.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
            kitap.KATEGORI = ktg.ID;
            kitap.YAZAR = yzr.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}