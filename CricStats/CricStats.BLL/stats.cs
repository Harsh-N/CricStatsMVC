using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.BLL
{
    public class Stats
    {
        private readonly DAL.Stats _db;

        #region "Constructors"
        public Stats(string strConnection)
        {
            _db = new DAL.Stats(strConnection);
        }
        #endregion


        //save data row table in database
        public IEnumerable<Models.Stats> GetAllStats()
        {
            var outList = new List<Models.Stats>();

            DataTable dt = _db.GetAllStats();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    outList.Add(new Models.Stats(dr));
                }
            }

            return outList;
        }

        public IEnumerable<Models.Stats> GetAllStatsComparison(int player1, int player2)
        {
            var outList = new List<Models.Stats>();

            DataTable dt = _db.GetAllStatsComparisons(player1, player2);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    outList.Add(new Models.Stats(dr));
                }
            }

            return outList;
        }
    }
}
