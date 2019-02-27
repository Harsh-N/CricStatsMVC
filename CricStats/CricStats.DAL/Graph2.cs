using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.DAL 
{
    public class Graph2 : DAL.BaseClass.DALBase
    {
        public Graph2(string strConnString) : base(strConnString) { }

        public DataTable highestRunScorersForMatch()
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[Top5RunScorers]";

            try
            {
                return DTReturn(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
