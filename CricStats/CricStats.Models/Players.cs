using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.Models
{
    public class Players
    {
        #region private fields
        private Int32 _PlayerId;
        private string _PlayerName;
        #endregion

        #region properties
        public Int32 PlayerId
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
        [StringLength(1)]
        [Required(ErrorMessage = "Player Name required")]
        public String PlayerName
        {
            get
            {
                return _PlayerName;
            }
            set
            {
                if (_PlayerName != value)
                {
                    _PlayerName = value;
                }
            }
        }
        #endregion 

        #region "Constructors"
        public Players() { }

        public Players(DataRow dr)
            : base()
        {
            InitFromDB(dr);
        }
        #endregion

        public void InitFromDB(DataRow dr)
        {
            if (dr == null)
            {
                throw new ArgumentNullException("dr");
            }

            if ((dr["PlayerId"]) != DBNull.Value) { _PlayerId = (System.Int32)(dr["PlayerId"]); }
            if ((dr["playerName"]) != DBNull.Value) { _PlayerName = (System.String)(dr["playerName"]); }
        }
    }
}
