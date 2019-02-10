using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.DAL
{
    public class News : DAL.BaseClass.DALBase
    {
        public News(string strConnString) : base(strConnString) { }

        public DataTable GetAllNewsElements()
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[GetAllNewsElements]";

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
