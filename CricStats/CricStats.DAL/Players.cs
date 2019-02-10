using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.DAL
{
    public class Players : DAL.BaseClass.DALBase
    {
        public Players(string strConnString) : base(strConnString) { }

        public DataTable GetAllPlayers()
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[GetAllPlayers]";           

            try
            {
                return DTReturn(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Save(ref Models.Players item)
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[SavePlayer]";

          
            cmd.Parameters.Add("@playerName", SqlDbType.NVarChar, 50).Value = item.PlayerName;

            try
            {
                SafeOpen();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                FinallyClose();
            }
        }

        public DataRow checkPlayer(string playerName) {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[checkPlayer]";

            cmd.Parameters.Add("@playerName", SqlDbType.NVarChar, 50).Value = playerName;
            try
            {
               return DRReturn(cmd);
            }
            catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }

    }
}
