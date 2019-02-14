using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.DAL
{
    public class Performance : DAL.BaseClass.DALBase
    {
        public Performance(string strConnString) : base(strConnString) { }

        public DataTable GetAllPerformance()
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[GetAllPerformance]";

            try
            {
                return DTReturn(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Save(ref Models.Performance item)
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[SavePerformance]";

            cmd.Parameters.Add("@MatchId", SqlDbType.Int).Value = item.MatchId;
            cmd.Parameters.Add("@PlayerId", SqlDbType.Int).Value = item.PlayerId;
            cmd.Parameters.Add("@runsScored", SqlDbType.Int).Value = item.runsScored;
            cmd.Parameters.Add("@ballsFaced", SqlDbType.Int).Value = item.ballsFaced;
            cmd.Parameters.Add("@Fours", SqlDbType.Int).Value = item.Fours;
            cmd.Parameters.Add("@Sixes", SqlDbType.Int).Value = item.Sixes;
            cmd.Parameters.Add("@wicketsTaken", SqlDbType.Int).Value = item.wicketsTaken;
            cmd.Parameters.Add("@oversBowled", SqlDbType.Int).Value = item.oversBowled;
            cmd.Parameters.Add("@runConceded", SqlDbType.Int).Value = item.runConceded;
            cmd.Parameters.Add("@Catches", SqlDbType.Int).Value = item.Catches;
            cmd.Parameters.Add("@runOuts", SqlDbType.Int).Value = item.runOuts;
            cmd.Parameters.Add("@BattingStrikeRate", SqlDbType.Int).Value = item.BattingStrikeRate;
            cmd.Parameters.Add("@BowlingEconomy", SqlDbType.Int).Value = item.BowlingEconomy;
            cmd.Parameters.Add("@Out", SqlDbType.Int).Value = item.Out;
            cmd.Parameters.Add("@BowlingAverage", SqlDbType.Int).Value = item.BowlingAverage;


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

        //public DataRow checkMatches(DateTime dateofMatch, string homeTeam, string OppositionTeam)
        //{
        //    var cmd = new SqlCommand();

        //    cmd.Connection = Connection;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "[dbo].[checkMatch]";

        //    cmd.Parameters.Add("@dateOfMatches", SqlDbType.DateTime).Value = dateofMatch;
        //    cmd.Parameters.Add("@HomeTeam", SqlDbType.NVarChar, 50).Value = homeTeam;
        //    cmd.Parameters.Add("@OppositionTeam", SqlDbType.NVarChar, 50).Value = OppositionTeam;
        //    try
        //    {
        //        return DRReturn(cmd);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
