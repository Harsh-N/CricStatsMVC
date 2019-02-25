using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CricStats.Controllers
{
    public class StatsController : Controller
    {
        // GET: Stats
        public ActionResult Index()
        {
            return View();
        }

        private static readonly string _conStr = ConfigurationManager.ConnectionStrings["CricSatsConnection"].ConnectionString;


        [HttpGet]
        [ActionName("getstats")]
        public string GetAllStats()
        {
            CricStats.BLL.stats statsBll = new BLL.stats(_conStr);
            var Allstats = statsBll.GetAllStats();
            JavaScriptSerializer s = new JavaScriptSerializer();
            string sResult = s.Serialize(Allstats);
            return sResult;
            //return Json(AllPlayers, JsonRequestBehavior.AllowGet);
        }
    }
}