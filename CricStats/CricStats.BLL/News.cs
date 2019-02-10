using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.BLL
{
    public class News
    {
        private readonly DAL.News _db;

        #region "Constructors"
        public News(string strConnection)
        {
            _db = new DAL.News(strConnection);
        }
        #endregion

        public IEnumerable<Models.News> GetAllNewsElements()
        {
            var outList = new List<Models.News>();

            DataTable dt = _db.GetAllNewsElements();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    outList.Add(new Models.News(dr));
                }
            }

            return outList;
        }
    }
}
