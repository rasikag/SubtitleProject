using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SubtitleProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Files"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("ReadFile");
        }

        [HttpGet]
        public ActionResult ReadFile()
        {
            try
            {
                string content = string.Empty;
                using (var stream = new StreamReader(Server.MapPath("~/Files/Transporter.srt")))
                {
                    content = stream.ReadToEnd();
                }
                return Content(content);
            }
            catch (Exception ex)
            {
                return Content("Something went wrong");
            }

            //return View();
        }


    }
}