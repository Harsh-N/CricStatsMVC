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
    public class GraphController : Controller
    {
        private static readonly string _conStr = ConfigurationManager.ConnectionStrings["CricSatsConnection"].ConnectionString;
        // GET: Graph
        public ActionResult Index()
        {
            CricStats.BLL.Graph1 GraphBll = new BLL.Graph1(_conStr);
            var Graph = GraphBll.GetGraphData();           

            ViewBag.DataPoints = JsonConvert.SerializeObject(Graph);


            CricStats.BLL.Graph2 Graph2Bll = new BLL.Graph2(_conStr);
            var Graph2 = Graph2Bll.GetGraphData();

            ViewBag.DataPoints2 = JsonConvert.SerializeObject(Graph2);


            CricStats.BLL.Graph3 Graph3Bll = new BLL.Graph3(_conStr);
            var Graph3 = Graph3Bll.GetGraphData();

            ViewBag.DataPoints3 = JsonConvert.SerializeObject(Graph3);

            return View();
        }

       


      

    }
}