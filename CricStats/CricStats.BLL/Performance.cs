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


        //check for duplicate entry of match
        //public Models.Matches checkMatches(DateTime dateOfMatch, string homeTeam, string oppositionTeam)
        //{
        //    Models.Matches temp = null;

        //    DataRow dr = _db.checkMatches(dateOfMatch, homeTeam, oppositionTeam);

        //    if (dr != null)
        //    {
        //        temp = new Models.Matches(dr);
        //    }

        //    return temp;
        //}
    }
}
