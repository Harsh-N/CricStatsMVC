﻿using System;
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
        private int _BattingAverage;

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

        public int BattingAverage
        {
            get
            {
                return _BattingAverage;
            }
            set
            {
                if (_BattingAverage != value)
                {
                    _BattingAverage = value;
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
            if ((dr["BattingAverage"]) != DBNull.Value) { _BattingAverage = (System.Int32)(dr["BattingAverage"]); }
        }
    }
}
