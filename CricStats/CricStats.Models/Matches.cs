using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.Models
{
   public class Matches
    {
        #region private fields
        private Int32 _MatchId;
        private DateTime _dateOfMatch;
        private string _HomeTeam;
        private string _OppositionTeam;
        private bool _isTossWin;
        private int _HomeScore;
        private int _HomeWicketsFallen;
        private int _OppositionScore;
        private int _OppositionWicketsFallen;
        private bool _isWin;
        #endregion

        #region properties
        public Int32 MatchId
        {
            get
            {
                return _MatchId;
            }
            set
            {
                if (_MatchId != value)
                {
                    _MatchId = value;
                }
            }
        }
        public DateTime DateOfMatch
        {
            get
            {
                return _dateOfMatch;
            }
            set
            {
                if (_dateOfMatch != value)
                {
                    _dateOfMatch = value;
                }
            }
        }

        public string HomeTeam
        {
            get
            {
                return _HomeTeam;
            }
            set
            {
                if (_HomeTeam != value)
                {
                    _HomeTeam = value;
                }
            }
        }

        public String OppositionTeam
        {
            get
            {
                return _OppositionTeam;
            }
            set
            {
                if (_OppositionTeam != value)
                {
                    _OppositionTeam = value;
                }
            }
        }

        public Boolean isTossWin
        {
            get
            {
                return _isTossWin;
            }
            set
            {
                if (_isTossWin != value)
                {
                    _isTossWin = value;
                }
            }
        }

        public int HomeScore
        {
            get
            {
                return _HomeScore;
            }
            set
            {
                if (_HomeScore != value)
                {
                    _HomeScore = value;
                }
            }
        }

        public int HomeWicketsFallen
        {
            get
            {
                return _HomeWicketsFallen;
            }
            set
            {
                if (_HomeWicketsFallen != value)
                {
                    _HomeWicketsFallen = value;
                }
            }
        }

        public int OppositionScore
        {
            get
            {
                return _OppositionScore;
            }
            set
            {
                if (_OppositionScore != value)
                {
                    _OppositionScore = value;
                }
            }
        }

        public int OppositionWicketsFallen
        {
            get
            {
                return _OppositionWicketsFallen;
            }
            set
            {
                if (_OppositionWicketsFallen != value)
                {
                    _OppositionWicketsFallen = value;
                }
            }
        }

        public Boolean isWin
        {
            get
            {
                return _isWin;
            }
            set
            {
                if (_isWin != value)
                {
                    _isWin = value;
                }
            }
        }
        #endregion
        #region "Constructors"
       
        public Matches(DataRow dr)
            : base()
        {
            InitFromDB(dr);
        }

        public Matches()
        {
        }
        #endregion

        public void InitFromDB(DataRow dr)
        {
            if (dr == null)
            {
                throw new ArgumentNullException("dr");
            }

            if ((dr["MatchId"]) != DBNull.Value) { _MatchId = (System.Int32)(dr["MatchId"]); }
            if ((dr["dateOfMatch"]) != DBNull.Value) { _dateOfMatch = (System.DateTime)(dr["dateOfMatch"]); }
            if ((dr["HomeTeam"]) != DBNull.Value) { _HomeTeam = (System.String)(dr["HomeTeam"]); }
            if ((dr["OppositionTeam"]) != DBNull.Value) { _OppositionTeam = (System.String)(dr["OppositionTeam"]); }
            if ((dr["isTossWin"]) != DBNull.Value) { _isTossWin = (System.Boolean)(dr["isTossWin"]); }
            if ((dr["homeScore"]) != DBNull.Value) { _HomeScore = (System.Int32)(dr["homeScore"]); }
            if ((dr["homeWicketsFallen"]) != DBNull.Value) { _HomeWicketsFallen = (System.Int32)(dr["homeWicketsFallen"]); }
            if ((dr["oppositionScore"]) != DBNull.Value) { _OppositionScore = (System.Int32)(dr["oppositionScore"]); }
            if ((dr["oppositionWicketsFallen"]) != DBNull.Value) { _OppositionWicketsFallen = (System.Int32)(dr["oppositionWicketsFallen"]); }
            if ((dr["isWin"]) != DBNull.Value) { _isWin = (System.Boolean)(dr["isWin"]); }
        }
    }
}
