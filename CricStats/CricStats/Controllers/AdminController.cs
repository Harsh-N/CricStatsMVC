using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CricStats.Models;
using System.Configuration;
namespace CricStats.Controllers

{
    public class AdminController : Controller
    {
        private static readonly string _conStr = ConfigurationManager.ConnectionStrings["CricSatsConnection"].ConnectionString;

        // GET: Admin
        public ActionResult AdminMain()
        {
            LoadDropDowns();

            return View();
        }

        [HttpPost]
        public string SavePlayer(string PlayerName)
        {
            CricStats.Models.Players NewPlayer = new Players();
            CricStats.BLL.Players PlayerBLL = new BLL.Players(_conStr);

            NewPlayer.PlayerName = PlayerName;
            try
            {
                if (PlayerBLL.checkPlayers(PlayerName) == null)
                {
                    PlayerBLL.Save(NewPlayer);
                    return "1";
                }
                else {
                    return "2";
                }
               
            }
            catch {
                return "0"; 
            }
        }

        public void LoadDropDowns() {
            CricStats.BLL.Players PlayerBLL = new BLL.Players(_conStr);
            var PlayerList = PlayerBLL.GetAllPlayers();

            var pList = PlayerList.Select(x => new SelectListItem { Text = x.PlayerName, Value = x.PlayerId.ToString() }).ToList();
            pList.Insert(0, new SelectListItem() { Value = "0", Text = "Select...", Selected = true });
            ViewBag.listOfPlayers = pList;
        }



        //public JsonResult SavePlayer()
        //{
        //    var PlayerId = decimal.Parse(Request.Form["PlayerId"]);
        //    var playerName = Request.Form["playerName"];

        //    //var runsScored = Int32.Parse(Request.Form["runsScored"]);
        //    //var ballFaced = Int32.Parse(Request.Form["ballFaced"]);
        //    //var Fours = Int32.Parse(Request.Form["Fours"]);
        //    //var Sixes = Int32.Parse(Request.Form["Sixes"]);
        //    //var wicketsTaken = Int32.Parse(Request.Form["wicketsTaken"]);
        //    //var oversBowled = Int32.Parse(Request.Form["oversBowled"]);
        //    //var runConceded = Int32.Parse(Request.Form["runConceded"]);
        //    //var Catches = Int32.Parse(Request.Form["Catches"]);
        //    //var runOuts = Int32.Parse(Request.Form["runOuts"]);
        //    //var BattingStrikeRate = Int32.Parse(Request.Form["BattingStrikeRate"]);
        //    //var BowlingEconomy = Int32.Parse(Request.Form["BowlingEconomy"]);
        //    //var BattingAverage = Int32.Parse(Request.Form["BattingAverage"]);

        //    bool status = true;
        //    string msg = "";

        //    if (string.IsNullOrEmpty(playerName))
        //    {
        //        status = false;
        //        msg += "Please add player name\n";
        //    }


        //    if (status)
        //    {
        //        using (DBEntities db = new DBEntities())
        //        {
        //            Player player;
        //            MatchPlayer performance;
        //            Match match;

        //            if (PlayerId == 0)
        //            {

        //                try
        //                {
        //                    //performance = new MatchPlayer();
        //                    player = new Player();
        //                    //match = new Match();

        //                    player.playerName = playerName;
        //                    db.Players.Add(player);


        //                    List<Player> pList = new List<Player>();



        //                    //performance.runsScored = runsScored;
        //                    //performance.ballsFaced = ballFaced;
        //                    //performance.Fours = Fours;
        //                    //performance.Sixes = Sixes;
        //                    //performance.wicketsTaken = wicketsTaken;
        //                    //performance.oversBowled = oversBowled;
        //                    //performance.runConceded = runConceded;
        //                    //performance.Catches = Catches;
        //                    //performance.runOuts = runOuts;
        //                    //performance.BattingStrikeRate = BattingStrikeRate;
        //                    //performance.BowlingEconomy = BowlingEconomy;
        //                    //performance.BattingAverage = BattingAverage;

        //                    //performance.PlayerId = player.PlayerId;
        //                    //performance.MatchId = 0;

        //                    //db.MatchPlayers.Add(performance);
        //                    db.SaveChanges();

        //                    //var x = performance.MatchId;
        //                }
        //                catch (Exception ex) {
        //                    Console.Write(ex.ToString());
        //                }

        //            }
        //            else
        //            {
        //                player = db.Players.FirstOrDefault(x => x.PlayerId == PlayerId);
        //            }
        //        }
        //    }
        //    return Json(new { });
        //}






        //public Boolean Saveform(Player model) {

        //    //validate

        //    using (DBEntities db = new DBEntities()) {
        //        db.Players.Add(model);
        //    }
        //}



    }
}