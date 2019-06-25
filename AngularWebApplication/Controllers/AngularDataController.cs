using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularWebApplication.Controllers
{
    public class AngularDataController : Controller
    {

        //DbContext
        
        // GET: AngularData
        public ActionResult Index()
        {
            return View();
        }
    }
}