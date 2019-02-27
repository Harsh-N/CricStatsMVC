using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.Models
{
    public class Graph1
    {
        private string _MatchPlayer;
        private int _runsScored;

        public String MatchPlayer
        {
            get
            {
                return _MatchPlayer;
            }
            set
            {
                if (_MatchPlayer != value)
                {
                    _MatchPlayer = value;
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

        public Graph1() { }

        public Graph1(DataRow dr)
            : base()
        {
            InitFromDB(dr);
        }
  

        public void InitFromDB(DataRow dr)
        {
            if (dr == null)
            {
                throw new ArgumentNullException("dr");
            }

            if ((dr["MatchPlayer"]) != DBNull.Value) { _MatchPlayer = (System.String)(dr["MatchPlayer"]); }
            if ((dr["runsScored"]) != DBNull.Value) { _runsScored = (System.Int32)(dr["runsScored"]); }
        }
    }
}
