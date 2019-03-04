using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CricStats.Controllers
{
    public class ResultsController : Controller
    {
        private static readonly string _conStr = ConfigurationManager.ConnectionStrings["CricSatsConnection"].ConnectionString;

        // GET: Results
        public ActionResult Index()
        {
            CricStats.BLL.Matches MatchesBll = new BLL.Matches(_conStr);
            var AllMatches = MatchesBll.GetAllMatches();
           // JavaScriptSerializer s = new JavaScriptSerializer();
           // string sResult = s.Serialize(AllMatches);
            ViewBag.scoreCards = JsonConvert.SerializeObject(AllMatches);


            return View();
        }
    }
}