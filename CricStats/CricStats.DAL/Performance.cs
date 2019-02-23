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
            cmd.Parameters.Add("@Out", SqlDbType.Bit).Value = item.Out;
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

        public void Update(
             int PId,
             int MId,
             int runsScored,
             int ballsFaced,
             int Fours,
             int Sixes,
             int wicketsTaken,
             int oversBowled,
             int runConceded,
             int Catches,
             int runOuts,
             int BattingStrikeRate,
             int BowlingEconomy, 
             Boolean Out,
             int BowlingAverage)
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[updatePerformance]";

            cmd.Parameters.Add("@PlayerId", SqlDbType.Int).Value = PId;
            cmd.Parameters.Add("@MatchId", SqlDbType.Int).Value = MId;
            cmd.Parameters.Add("@runsScored", SqlDbType.Int).Value = runsScored;
            cmd.Parameters.Add("@ballsFaced", SqlDbType.Int).Value = ballsFaced;
            cmd.Parameters.Add("@Fours", SqlDbType.Int).Value = Fours;
            cmd.Parameters.Add("@Sixes", SqlDbType.Int).Value = Sixes;
            cmd.Parameters.Add("@wicketsTaken", SqlDbType.Int).Value = wicketsTaken;
            cmd.Parameters.Add("@oversBowled", SqlDbType.Int).Value = oversBowled;
            cmd.Parameters.Add("@runConceded", SqlDbType.Int).Value = runConceded;
            cmd.Parameters.Add("@Catches", SqlDbType.Int).Value = Catches;
            cmd.Parameters.Add("@runOuts", SqlDbType.Int).Value = runOuts;
            cmd.Parameters.Add("@BattingStrikeRate", SqlDbType.Int).Value = BattingStrikeRate;
            cmd.Parameters.Add("@BowlingEconomy", SqlDbType.Int).Value = BowlingEconomy;
            cmd.Parameters.Add("@Out", SqlDbType.Bit).Value = Out;
            cmd.Parameters.Add("@BowlingAverage", SqlDbType.Int).Value = BowlingAverage;


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

        public void DeletePerformance(int PlayerId, int MatchId) {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[deletePerformance]";

            cmd.Parameters.Add("@PlayerId", SqlDbType.Int).Value = PlayerId;
            cmd.Parameters.Add("@MatchId", SqlDbType.Int).Value = MatchId;

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
