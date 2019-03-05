using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.DAL
{
    public class Stats: DAL.BaseClass.DALBase
    {
        public Stats(string strConnString) : base(strConnString) { }

        public DataTable GetAllStats()
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[RetrivePlayersPerformance]";

            try
            {
                return DTReturn(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable GetAllStatsComparisons(int player1, int player2)
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[getComparison]";


            cmd.Parameters.Add("@player1", SqlDbType.Int).Value = player1;
            cmd.Parameters.Add("@player2", SqlDbType.Int).Value = player2;
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
