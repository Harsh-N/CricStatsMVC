using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.BLL
{
   public class Performance
    {
        private readonly DAL.Performance _db;

        #region "Constructors"
        public Performance(string strConnection)
        {
            _db = new DAL.Performance(strConnection);
        }
        #endregion


        //save data row table in database
        public IEnumerable<Models.Performance> GetAllPerformance()
        {
            var outList = new List<Models.Performance>();

            DataTable dt = _db.GetAllPerformance();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    outList.Add(new Models.Performance(dr));
                }
            }

            return outList;
        }

        public void Save(Models.Performance tmp)
        {
            _db.Save(ref tmp);
        }

        public void Update(
             int PId,
             int MId,
             int runsScored,
             int ballsFaced,
             int Fours,
             int Sixes,
             int wicketsTaken,
             int oversBowled,
             int runConceded,
             int Catches,
             int runOuts,
             int BattingStrikeRate,
             int BowlingEconomy,
             Boolean Out,
             int BowlingAverage,
             string HowOut)
        {
            _db.Update(PId, MId, runsScored, ballsFaced, Fours, Sixes, wicketsTaken, oversBowled, runConceded, Catches, runOuts, BattingStrikeRate, BowlingEconomy, Out, BowlingAverage, HowOut);
        }

        public void DeletePerformance(int PlayerId, int MatchId) {
            _db.DeletePerformance(PlayerId, MatchId);
        }

    }
}
