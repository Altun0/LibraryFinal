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
        public ActionResult Index()
        {
            var kitaplar = db.TBLKITAPs.ToList();
            return View(kitaplar);
        }
    }
}