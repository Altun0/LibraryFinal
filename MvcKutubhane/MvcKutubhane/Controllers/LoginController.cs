using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutubhane.Models.Entity;
using System.Web.Security;
namespace MvcKutubhane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBKUTUBHANEEntities db = new DBKUTUBHANEEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult GirisYap(TBLUYELER p)
        {
            var bilgiler = db.TBLUYELERs.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }

    }
}