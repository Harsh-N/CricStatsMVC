using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CricStats.DAL;

namespace CricStats.BLL
{
    public class Players
    {
        private readonly DAL.Players _db;

        #region "Constructors"
        public Players(string strConnection)
        {
            _db = new DAL.Players(strConnection);
        }
        #endregion

        public IEnumerable<Models.Players> GetAllPlayers()
        {
            var outList = new List<Models.Players>();

            DataTable dt = _db.GetAllPlayers();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    outList.Add(new Models.Players(dr));
                }
            }

            return outList;
        }

        public void Save(Models.Players tmp)
        {
            _db.Save(ref tmp); 
        }

        public void Update(int PlayerId, string PlayerName)
        {
            _db.Update(PlayerId, PlayerName);
        }

        public void deletePlayer(int PlayerId) {
            _db.DeletePlayer(PlayerId);
        }

        public Models.Players checkPlayers(string PlayerName) {
            Models.Players temp = null;

            DataRow dr = _db.checkPlayer(PlayerName);

            if (dr != null) {
                temp = new Models.Players(dr);
            }

            return temp;
        }

    }
}
