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

        [HttpPost]
        public string SaveMatches(
            DateTime dateOfMatch, 
            string HomeTeam,
            string OppositionTeam,
            bool isTossWin,
            int homeScore,
            int homeWicketsFallen,
            int oppositionScore,
            int oppositionWicketsFallen,
            bool isWin)
        {
            CricStats.Models.Matches NewMatch = new Matches();
            CricStats.BLL.Matches MatchesBLL = new BLL.Matches(_conStr);

            NewMatch.DateOfMatch = dateOfMatch;
            NewMatch.HomeTeam = HomeTeam;
            NewMatch.OppositionTeam = OppositionTeam;
            NewMatch.isTossWin = isTossWin;
            NewMatch.HomeScore = homeScore;
            NewMatch.HomeWicketsFallen = homeWicketsFallen;
            NewMatch.OppositionScore = oppositionScore;
            NewMatch.OppositionWicketsFallen = oppositionWicketsFallen;
            NewMatch.isWin = isWin;

            try
            {
                if (MatchesBLL.checkMatches(dateOfMatch, HomeTeam, OppositionTeam) == null)
                {
                    MatchesBLL.Save(NewMatch);
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

            var mList = MatchList.Select(x => new SelectListItem { Text = x.DateOfMatch.ToString()+ x.HomeTeam+ x.OppositionTeam, Value = x.MatchId.ToString() }).ToList();
            mList.Insert(0, new SelectListItem() { Value = "0", Text = "Select...", Selected = true });
            ViewBag.listOfMatches = mList;
        }



       



    }
}