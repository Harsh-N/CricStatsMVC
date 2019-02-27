using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.BLL
{
    public class Graph2
    {
        private readonly DAL.Graph2 _db;

        #region "Constructors"
        public Graph2(string strConnection)
        {
            _db = new DAL.Graph2(strConnection);
        }
        #endregion

        public IEnumerable<Models.Graph2> GetGraphData()
        {
            var outList = new List<Models.Graph2>();

            DataTable dt = _db.highestRunScorersForMatch();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    outList.Add(new Models.Graph2(dr));
                }
            }

            return outList;
        }
    }
}
