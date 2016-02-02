using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SubtitleProject.Models;

namespace SubtitleProject.Controllers
{
    public class HomeController : Controller
    {
 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SinglePage()
        {
            return View();
        }

    }
}