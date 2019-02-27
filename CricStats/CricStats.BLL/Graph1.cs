using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.BLL
{
   public class Graph1
    {
        private readonly DAL.Graph1 _db;

        #region "Constructors"
        public Graph1(string strConnection)
        {
            _db = new DAL.Graph1(strConnection);
        }
        #endregion

        public IEnumerable<Models.Graph1> GetGraphData()
        {
            var outList = new List<Models.Graph1>();

            DataTable dt = _db.highestRunScorersForMatch();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    outList.Add(new Models.Graph1(dr));
                }
            }

            return outList;
        }
    }
}
