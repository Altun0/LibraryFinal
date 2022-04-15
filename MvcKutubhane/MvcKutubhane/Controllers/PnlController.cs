using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutubhane.Controllers
{
    public class PnlController : Controller
    {
        // GET: Pnl
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}