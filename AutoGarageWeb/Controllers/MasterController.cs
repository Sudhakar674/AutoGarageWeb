using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoGarageWeb.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult CarListMaster()
        {
            return View();
        }
    }
}