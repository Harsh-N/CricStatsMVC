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
            LoadDropDowns();
            return View();
        }

        private static readonly string _conStr = ConfigurationManager.ConnectionStrings["CricSatsConnection"].ConnectionString;


        [HttpGet]
        [ActionName("getstats")]
        public string GetAllStats()
        {
            CricStats.BLL.Stats statsBll = new BLL.Stats(_conStr);
            var Allstats = statsBll.GetAllStats();
            JavaScriptSerializer s = new JavaScriptSerializer();
            string sResult = s.Serialize(Allstats);
            return sResult;
            //return Json(AllPlayers, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("getCompariosn")]
        public string GetAllStatsComparison(string player1, string player2)
        {
            CricStats.BLL.Stats statsBll = new BLL.Stats(_conStr);
            var Allstats = statsBll.GetAllStatsComparison(Convert.ToInt32(player1), Convert.ToInt32(player2));
            JavaScriptSerializer s = new JavaScriptSerializer();
            string sResult = s.Serialize(Allstats);
            return sResult;
            //return Json(AllPlayers, JsonRequestBehavior.AllowGet);
        }

        public void LoadDropDowns()
        {
            //LoadDropDowns for player
            CricStats.BLL.Players PlayerBLL = new BLL.Players(_conStr);
            var PlayerList = PlayerBLL.GetAllPlayers();

            var pList = PlayerList.Select(x => new SelectListItem { Text = x.PlayerName, Value = x.PlayerId.ToString() }).ToList();
            pList.Insert(0, new SelectListItem() { Value = "0", Text = "Select...", Selected = true });
            ViewBag.listOfPlayers = pList;
        }
    }
}