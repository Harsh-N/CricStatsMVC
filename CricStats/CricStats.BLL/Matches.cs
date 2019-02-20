using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.BLL
{
    public class Matches
    {
        private readonly DAL.Matches _db;

        #region "Constructors"
        public Matches(string strConnection)
        {
            _db = new DAL.Matches(strConnection);
        }
        #endregion


        //save data row table in database
        public IEnumerable<Models.Matches> GetAllMatches()
        {
            var outList = new List<Models.Matches>();

            DataTable dt = _db.GetAllMatches();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    outList.Add(new Models.Matches(dr));
                }
            }

            return outList;
        }

        public void Save(Models.Matches tmp)
        {
            _db.Save(ref tmp);
        }

        public void Update(
            int MatchId,
            string HomeTeam,
            string OppositionTeam,
            DateTime dateOfMatch,
            Boolean isTossWon,
            int homeScore,
            int homeTeamOvers,
            int homeWicketsFallen,
            int oppositionScore,
            int oppositionTeamOvers,
            int oppositionWicketsFallen,
            Boolean isWin)
        {
            _db.Update(MatchId, HomeTeam, OppositionTeam, dateOfMatch, isTossWon, homeScore, homeTeamOvers, homeWicketsFallen, oppositionScore, oppositionTeamOvers, oppositionWicketsFallen, isWin); 
        }


        //check for duplicate entry of match
        public Models.Matches checkMatches(DateTime dateOfMatch, string homeTeam, string oppositionTeam)
        {
            Models.Matches temp = null;

            DataRow dr = _db.checkMatches(dateOfMatch, homeTeam, oppositionTeam);

            if (dr != null)
            {
                temp = new Models.Matches(dr);
            }

            return temp;
        }
    }
}
