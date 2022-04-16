using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutubhane.Models.Entity;
namespace MvcKutubhane.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}