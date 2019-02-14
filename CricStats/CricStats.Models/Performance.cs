using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.Models
{
   public class Performance
    {
        #region private fields
        private int _MatchId;
        private int _PlayerId;
        private int _runsScored;
        private int _ballsFaced;
        private int _Fours;
        private int _Sixes;
        private int _wicketsTaken;
        private int _oversBowled;
        private int _runConceded;
        private int _Catches;
        private int _runOuts;
        private int _BattingStrikeRate;
        private int _BowlingEconomy;
        private bool _Out;
        private int _BowlingAverage;
        #endregion

        public int MatchId
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

        public int PlayerId
        {
            get
            {
                return _PlayerId;
            }
            set
            {
                if (_PlayerId != value)
                {
                    _PlayerId = value;
                }
            }
        }

        public int runsScored
        {
            get
            {
                return _runsScored;
            }
            set
            {
                if (_runsScored != value)
                {
                    _runsScored = value;
                }
            }
        }

        public int ballsFaced
        {
            get
            {
                return _ballsFaced;
            }
            set
            {
                if (_ballsFaced != value)
                {
                    _ballsFaced = value;
                }
            }
        }

        public int Fours
        {
            get
            {
                return _Fours;
            }
            set
            {
                if (_Fours != value)
                {
                    _Fours = value;
                }
            }
        }

        public int Sixes
        {
            get
            {
                return _Sixes;
            }
            set
            {
                if (_Sixes != value)
                {
                    _Sixes = value;
                }
            }
        }

        public int wicketsTaken
        {
            get
            {
                return _wicketsTaken;
            }
            set
            {
                if (_wicketsTaken != value)
                {
                    _wicketsTaken = value;
                }
            }
        }

        public int oversBowled
        {
            get
            {
                return _oversBowled;
            }
            set
            {
                if (_oversBowled != value)
                {
                    _oversBowled = value;
                }
            }
        }

        public int runConceded
        {
            get
            {
                return _runConceded;
            }
            set
            {
                if (_runConceded != value)
                {
                    _runConceded = value;
                }
            }
        }

        public int Catches
        {
            get
            {
                return _Catches;
            }
            set
            {
                if (_Catches != value)
                {
                    _Catches = value;
                }
            }
        }

        public int BattingStrikeRate
        {
            get
            {
                return _BattingStrikeRate;
            }
            set
            {
                if (_BattingStrikeRate != value)
                {
                    _BattingStrikeRate = value;
                }
            }
        }

        public int runOuts
        {
            get
            {
                return _runOuts;
            }
            set
            {
                if (_runOuts != value)
                {
                    _runOuts = value;
                }
            }
        }

        public int BowlingEconomy
        {
            get
            {
                return _BowlingEconomy;
            }
            set
            {
                if (_BowlingEconomy != value)
                {
                    _BowlingEconomy = value;
                }
            }
        }

        public bool Out
        {
            get
            {
                return _Out;
            }
            set
            {
                if (_Out != value)
                {
                    _Out = value;
                }
            }
        }

        public int BowlingAverage
        {
            get
            {
                return _BowlingAverage;
            }
            set
            {
                if (_BowlingAverage != value)
                {
                    _BowlingAverage = value;
                }
            }
        }


        #region "Constructors"

        public Performance(DataRow dr)
            : base()
        {
            InitFromDB(dr);
        }

        public Performance()
        {
        }
        #endregion

        public void InitFromDB(DataRow dr)
        {
            if (dr == null)
            {
                throw new ArgumentNullException("dr");
            }

            if ((dr["MatchId"]) != DBNull.Value) { _MatchId = (int)(dr["MatchId"]); }
            if ((dr["PlayerId"]) != DBNull.Value) { _PlayerId = (int)(dr["PlayerId"]); }
            if ((dr["runsScored"]) != DBNull.Value) { _runsScored = (int)(dr["runsScored"]); }
            if ((dr["ballsFaced"]) != DBNull.Value) { _ballsFaced = (int)(dr["ballsFaced"]); }
            if ((dr["Fours"]) != DBNull.Value) { _Fours = (int)(dr["Fours"]); }
            if ((dr["Sixes"]) != DBNull.Value) { _Sixes = (int)(dr["Sixes"]); }
            if ((dr["wicketsTaken"]) != DBNull.Value) { _wicketsTaken = (int)(dr["wicketsTaken"]); }
            if ((dr["oversBowled"]) != DBNull.Value) { _oversBowled = (int)(dr["oversBowled"]); }
            if ((dr["runConceded"]) != DBNull.Value) { _runConceded = (int)(dr["runConceded"]); }
            if ((dr["Catches"]) != DBNull.Value) { _Catches = (int)(dr["Catches"]); }
            if ((dr["runOuts"]) != DBNull.Value) { _runOuts = (int)(dr["runOuts"]); }
            if ((dr["BattingStrikeRate"]) != DBNull.Value) { _BattingStrikeRate = (int)(dr["BattingStrikeRate"]); }
            if ((dr["BowlingEconomy"]) != DBNull.Value) { _BowlingEconomy = (int)(dr["BowlingEconomy"]); }
            if ((dr["Out"]) != DBNull.Value) { _Out = (bool)(dr["Out"]); }
            if ((dr["BowlingAverage"]) != DBNull.Value) { _BowlingAverage = (int)(dr["BowlingAverage"]); }


        }



    }
}
