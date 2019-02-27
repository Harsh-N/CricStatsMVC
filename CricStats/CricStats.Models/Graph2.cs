using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.Models
{
    public class Graph2
    {
        private string _playerName;
        private int _runsScored;

        public String PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                if (_playerName != value)
                {
                    _playerName = value;
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

        public Graph2() { }

        public Graph2(DataRow dr)
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

            if ((dr["playerName"]) != DBNull.Value) { _playerName = (System.String)(dr["playerName"]); }
            if ((dr["runsScored"]) != DBNull.Value) { _runsScored = (System.Int32)(dr["runsScored"]); }
        }
    }
}
