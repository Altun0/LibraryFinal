using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutubhane.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcKutubhane.Controllers
 
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUBHANEEntities db = new DBKUTUBHANEEntities();

        public ActionResult Index(int sayfa=3)
        {
            //var degerler = db.TBLUYELERs.ToList();
            var degerler = db.TBLUYELERs.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLUYELERs.Add(p);
            db.SaveChanges();
            return View();
           }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYELERs.Find(id);
            db.TBLUYELERs.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYELERs.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            var uye = db.TBLUYELERs.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.OKUL = p.OKUL;
            uye.TELEFON = p.TELEFON;
            uye.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
    }