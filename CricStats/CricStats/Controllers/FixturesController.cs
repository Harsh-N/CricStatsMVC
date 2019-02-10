using CricStats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CricStats.Controllers
{
    public class FixturesController : Controller
    {
        // GET: Fixtures
        public ActionResult Index()
        {

            List<Match> Matchlist = new List<Match>();
            Match match = new Match();

            Matchlist.Add(new Match());

            return View();
        }
    }
}