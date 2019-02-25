using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.BLL
{
    public class stats
    {
        private readonly DAL.stats _db;

        #region "Constructors"
        public stats(string strConnection)
        {
            _db = new DAL.stats(strConnection);
        }
        #endregion


        //save data row table in database
        public IEnumerable<Models.stats> GetAllStats()
        {
            var outList = new List<Models.stats>();

            DataTable dt = _db.GetAllStats();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    outList.Add(new Models.stats(dr));
                }
            }

            return outList;
        }
    }
}
