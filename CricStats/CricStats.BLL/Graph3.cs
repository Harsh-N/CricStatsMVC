using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.BLL
{
    public class Graph3
    {
        private readonly DAL.Graph3 _db;

        #region "Constructors"
        public Graph3(string strConnection)
        {
            _db = new DAL.Graph3(strConnection);
        }
        #endregion

        public IEnumerable<Models.Graph3> GetGraphData()
        {
            var outList = new List<Models.Graph3>();

            DataTable dt = _db.gatewayTeamScores();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    outList.Add(new Models.Graph3(dr));
                }
            }

            return outList;
        }
    }
}
