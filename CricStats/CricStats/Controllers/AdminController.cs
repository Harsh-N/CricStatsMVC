using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CricStats.Models;
using System.Configuration;
using System.Web.Script.Serialization;

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
        public string SavePlayer(string PlayerId, string PlayerName)
        {
            CricStats.Models.Players NewPlayer = new Players();
            CricStats.BLL.Players PlayerBLL = new BLL.Players(_conStr);

            NewPlayer.PlayerName = PlayerName;
            try
            {
                if (PlayerBLL.checkPlayers(PlayerName) == null)
                {
                    if (Convert.ToInt32(PlayerId) == 0)
                    {
                        PlayerBLL.Save(NewPlayer);
                        
                    }
                    else if (Convert.ToInt32(PlayerId) != 0)
                    {
                        PlayerBLL.Update(Convert.ToInt32(PlayerId), PlayerName);
                        
                    }
                    return "1";
                }
                else
                {
                    return "2";
                }

            }
            catch
            {
                return "0";
            }
        }

        [HttpPost]
        public string SaveMatch(
            string MatchId,
            string HomeTeam,
            string OppositionTeam,
            string dateOfMatch,
            string isTossWon,
            string homeScore,
            string homeTeamOvers,
            string homeWicketsFallen,
            string oppositionScore,
            string oppositionTeamOvers,
            string oppositionWicketsFallen,
            string isWin)
        {
            CricStats.Models.Matches NewMatch = new Matches();
            CricStats.BLL.Matches MatchesBLL = new BLL.Matches(_conStr);

            NewMatch.DateOfMatch = Convert.ToDateTime(dateOfMatch);
            NewMatch.HomeTeam = HomeTeam;
            NewMatch.OppositionTeam = OppositionTeam;
            NewMatch.isTossWin = Convert.ToBoolean(isTossWon);
            NewMatch.HomeScore = Convert.ToInt32(homeScore);
            NewMatch.HomeTeamOvers = Convert.ToInt32(homeTeamOvers);
            NewMatch.HomeWicketsFallen = Convert.ToInt32(homeWicketsFallen);
            NewMatch.OppositionScore = Convert.ToInt32(oppositionScore);
            NewMatch.OppositionTeamOvers = Convert.ToInt32(oppositionTeamOvers);
            NewMatch.OppositionWicketsFallen = Convert.ToInt32(oppositionWicketsFallen);
            NewMatch.isWin = Convert.ToBoolean(isWin);

            try
            {
                if (Convert.ToInt32(MatchId) == 0)
                {
                    if (MatchesBLL.checkMatches(Convert.ToDateTime(dateOfMatch), HomeTeam, OppositionTeam) == null)
                    {
                        MatchesBLL.Save(NewMatch);
                    }
                    else
                    {
                        return "2";
                    }
                }
                else if (Convert.ToInt32(MatchId) != 0)
                {
                    MatchesBLL.Update(Convert.ToInt32(MatchId),
                        HomeTeam, OppositionTeam,
                       Convert.ToDateTime(dateOfMatch),
                       Convert.ToBoolean(isTossWon),
                       Convert.ToInt32(homeScore),
                       Convert.ToInt32(homeTeamOvers),
                       Convert.ToInt32(homeWicketsFallen),
                       Convert.ToInt32(oppositionScore),
                       Convert.ToInt32(oppositionTeamOvers),
                       Convert.ToInt32(oppositionWicketsFallen),
                       Convert.ToBoolean(isWin));
                }
                return "1";
            }
            catch (Exception ex)
            {
                var x = ex;
                return "0";
            }
        }

        [HttpPost]
        public string SavePerformance(
            string PlayerId,
            string MatchId,
            string runsScored,
            string ballsFaced,
            string Fours,
            string Sixes,
            string wicketsTaken,
            string oversBowled,
            string runConceded,
            string Catches,
            string runOuts,
            string BattingStrikeRate,
            string BowlingEconomy,
            string Out,
            string BowlingAverage)
        {
            CricStats.Models.Performance NewPerformance = new Performance();
            CricStats.BLL.Performance PerformanceBLL = new BLL.Performance(_conStr);

            NewPerformance.MatchId = Convert.ToInt32(MatchId);
            NewPerformance.PlayerId = Convert.ToInt32(PlayerId);
            NewPerformance.runsScored = Convert.ToInt32(runsScored);
            NewPerformance.ballsFaced = Convert.ToInt32(ballsFaced);
            NewPerformance.Fours = Convert.ToInt32(Fours);
            NewPerformance.Sixes = Convert.ToInt32(Sixes);
            NewPerformance.wicketsTaken = Convert.ToInt32(wicketsTaken);
            NewPerformance.oversBowled = Convert.ToInt32(oversBowled);
            NewPerformance.runConceded = Convert.ToInt32(runConceded);
            NewPerformance.Catches = Convert.ToInt32(Catches);
            NewPerformance.runOuts = Convert.ToInt32(runOuts);
            NewPerformance.BattingStrikeRate = Convert.ToInt32(BattingStrikeRate);
            NewPerformance.BowlingEconomy = Convert.ToInt32(BowlingEconomy);
            NewPerformance.Out = Convert.ToBoolean(Out);
            NewPerformance.BowlingAverage = Convert.ToInt32(BowlingAverage);



            try
            {
                //    if (MatchesBLL.checkMatches(Convert.ToDateTime(dateOfMatch), HomeTeam, OppositionTeam) == null)
                //    {
                PerformanceBLL.Save(NewPerformance);
                return "1";
            }
            //    else
            //    {
            //        return "2";
            //    }

            //}
            catch (Exception ex)
            {
                var x = ex;
                return "0";
            }
        }


        public void LoadDropDowns() {
            //LoadDropDowns for player
            CricStats.BLL.Players PlayerBLL = new BLL.Players(_conStr);
            var PlayerList = PlayerBLL.GetAllPlayers();

            var pList = PlayerList.Select(x => new SelectListItem { Text = x.PlayerName, Value = x.PlayerId.ToString() }).ToList();
            pList.Insert(0, new SelectListItem() { Value = "0", Text = "Select...", Selected = true });
            ViewBag.listOfPlayers = pList;


            //LoadDropDowns for match
            CricStats.BLL.Matches MatchesBLL = new BLL.Matches(_conStr);
            var MatchList = MatchesBLL.GetAllMatches();

            var mList = MatchList.Select(x => new SelectListItem { Text = x.DateOfMatch.ToString()+ " " + x.HomeTeam + " vs " + x.OppositionTeam, Value = x.MatchId.ToString() }).ToList();
            mList.Insert(0, new SelectListItem() { Value = "0", Text = "Select...", Selected = true });
            ViewBag.listOfMatches = mList;
        }


        [HttpGet]
        [ActionName("getPlayers")]
        public string GetAllPlayers() {
            CricStats.BLL.Players PlayersBll = new BLL.Players(_conStr);
            var AllPlayers = PlayersBll.GetAllPlayers();
            JavaScriptSerializer s = new JavaScriptSerializer();
            string sResult = s.Serialize(AllPlayers);
            return sResult;
            //return Json(AllPlayers, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("getMatches")]
        public string GetAllMatches()
        {
            CricStats.BLL.Matches MatchesBll = new BLL.Matches(_conStr);
            var AllMatches = MatchesBll.GetAllMatches();
            JavaScriptSerializer s = new JavaScriptSerializer();
            string sResult = s.Serialize(AllMatches);
            return sResult;
            //return Json(AllPlayers, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("getPerformance")]
        public string GetAllPerformance()
        {
            CricStats.BLL.Performance PerformanceBll = new BLL.Performance(_conStr);
            var AllPerformance = PerformanceBll.GetAllPerformance();
            JavaScriptSerializer s = new JavaScriptSerializer();
            string sResult = s.Serialize(AllPerformance);
            return sResult;
            //return Json(AllPlayers, JsonRequestBehavior.AllowGet);
        }






    }
}