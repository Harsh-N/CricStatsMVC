using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CricStats.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
          
        //image upload from folder to view dynamically
        ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/content/images/"))
                              .Select(fn => Path.GetFileName(fn));

        //videos upload from folder to view dynamically
        ViewBag.Videos = Directory.EnumerateFiles(Server.MapPath("~/content/videos/"))
                             .Select(fn => Path.GetFileName(fn));

            return View();
        }
    }
}