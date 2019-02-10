using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.Models
{
    public class News
    {
        private int _NewsId;
        private string _Title;
        private string _Article;
        private string _Image;

        public int NewsId { get => _NewsId; set => _NewsId = value; }
        public string Title { get => _Title; set => _Title = value; }
        public string Article { get => _Article; set => _Article = value; }
        public string Image { get => _Image; set => _Image = value; }

        #region "Constructors"
        public News() { }

        public News(DataRow dr)
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

            if ((dr["NewsId"]) != DBNull.Value) { _NewsId = (System.Int32)(dr["NewsId"]); }
            if ((dr["Title"]) != DBNull.Value) { _Title = (System.String)(dr["Title"]); }
            if ((dr["Article"]) != DBNull.Value) { _Article = (string)(dr["Article"]); }
            if ((dr["Image"]) != DBNull.Value) { _Image = (string)(dr["Image"]); }
        }
    }
}
