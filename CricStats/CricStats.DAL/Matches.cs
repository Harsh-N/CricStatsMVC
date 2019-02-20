using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricStats.DAL
{
    public class Matches : DAL.BaseClass.DALBase
    {
        public Matches(string strConnString) : base(strConnString) { }

        public DataTable GetAllMatches()
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[GetAllMatches]";

            try
            {
                return DTReturn(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Save(ref Models.Matches item)
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[SaveMatches]";


            cmd.Parameters.Add("@dateOfMatch", SqlDbType.DateTime).Value = item.DateOfMatch;
            cmd.Parameters.Add("@HomeTeam", SqlDbType.NVarChar, 50).Value = item.HomeTeam;
            cmd.Parameters.Add("@OppositionTeam", SqlDbType.NVarChar, 50).Value = item.OppositionTeam;
            cmd.Parameters.Add("@isTossWin", SqlDbType.Bit).Value = item.isTossWin;
            cmd.Parameters.Add("@homeScore", SqlDbType.Int).Value = item.HomeScore;
            cmd.Parameters.Add("@homeWicketsFallen", SqlDbType.Int).Value = item.HomeWicketsFallen;
            cmd.Parameters.Add("@HomeTeamOvers", SqlDbType.Int).Value = item.HomeTeamOvers;
            cmd.Parameters.Add("@oppositionScore", SqlDbType.Int).Value = item.OppositionScore;
            cmd.Parameters.Add("@oppositionWicketsFallen", SqlDbType.Int).Value = item.OppositionWicketsFallen;
            cmd.Parameters.Add("@OppositeTeamOvers", SqlDbType.Int).Value = item.OppositionTeamOvers;
            cmd.Parameters.Add("@iswin", SqlDbType.Bit).Value = item.isWin;
           

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
            int MatchId,
            string HomeTeam,
            string OppositionTeam,
            DateTime dateOfMatch,
            Boolean isTossWon,
            int homeScore,
            int homeTeamOvers,
            int homeWicketsFallen,
            int oppositionScore,
            int oppositionTeamOvers,
            int oppositionWicketsFallen,
            Boolean isWin)
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[updateMatch]";

            cmd.Parameters.Add("@MatchId", SqlDbType.Int).Value = MatchId;
            cmd.Parameters.Add("@dateOfMatch", SqlDbType.DateTime).Value = dateOfMatch;
            cmd.Parameters.Add("@HomeTeam", SqlDbType.NVarChar, 50).Value = HomeTeam;
            cmd.Parameters.Add("@OppositionTeam", SqlDbType.NVarChar, 50).Value = OppositionTeam;
            cmd.Parameters.Add("@isTossWin", SqlDbType.Bit).Value = isTossWon;
            cmd.Parameters.Add("@homeScore", SqlDbType.Int).Value = homeScore;
            cmd.Parameters.Add("@homeWicketsFallen", SqlDbType.Int).Value = homeWicketsFallen;
            cmd.Parameters.Add("@HomeTeamOvers", SqlDbType.Int).Value = homeTeamOvers;
            cmd.Parameters.Add("@oppositionScore", SqlDbType.Int).Value = oppositionScore;
            cmd.Parameters.Add("@oppositionWicketsFallen", SqlDbType.Int).Value = oppositionWicketsFallen;
            cmd.Parameters.Add("@OppositeTeamOvers", SqlDbType.Int).Value = oppositionTeamOvers;
            cmd.Parameters.Add("@iswin", SqlDbType.Bit).Value = isWin;


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

        public DataRow checkMatches(DateTime dateofMatch, string homeTeam, string OppositionTeam)
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[checkMatch]";

            cmd.Parameters.Add("@dateOfMatches", SqlDbType.DateTime).Value = dateofMatch;
            cmd.Parameters.Add("@HomeTeam", SqlDbType.NVarChar, 50).Value = homeTeam;
            cmd.Parameters.Add("@OppositionTeam", SqlDbType.NVarChar, 50).Value = OppositionTeam;
            try
            {
                return DRReturn(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
