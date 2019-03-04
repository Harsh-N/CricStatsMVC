using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.Models
{
   public class Graph3
    {
        private DateTime _Date;
        private int _TeamScore;

        public DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                if (_Date != value)
                {
                    _Date = value;
                }
            }
        }

        public int TeamScore
        {
            get
            {
                return _TeamScore;
            }
            set
            {
                if (_TeamScore != value)
                {
                    _TeamScore = value;
                }
            }
        }

        public Graph3() { }

        public Graph3(DataRow dr)
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

            if ((dr["Date"]) != DBNull.Value) { _Date = (System.DateTime)(dr["Date"]); }
            if ((dr["TeamScore"]) != DBNull.Value) { _TeamScore = (System.Int32)(dr["TeamScore"]); }
        }
    }
}
