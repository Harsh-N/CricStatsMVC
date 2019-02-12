﻿using System;
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


            cmd.Parameters.Add("@dateOfMatch", SqlDbType.NVarChar, 50).Value = item.DateOfMatch;
            cmd.Parameters.Add("@HomeTeam", SqlDbType.NVarChar, 50).Value = item.HomeTeam;
            cmd.Parameters.Add("@OppositionTeam", SqlDbType.NVarChar, 50).Value = item.OppositionTeam;
            cmd.Parameters.Add("@isTossWin", SqlDbType.NVarChar, 50).Value = item.isTossWin;
            cmd.Parameters.Add("@homeScore", SqlDbType.NVarChar, 50).Value = item.HomeScore;
            cmd.Parameters.Add("@homeWicketsFallen", SqlDbType.NVarChar, 50).Value = item.HomeWicketsFallen;
            cmd.Parameters.Add("@oppositionScore", SqlDbType.NVarChar, 50).Value = item.OppositionScore;
            cmd.Parameters.Add("@oppositionWicketsFallen", SqlDbType.NVarChar, 50).Value = item.OppositionWicketsFallen;
            cmd.Parameters.Add("@iswin", SqlDbType.NVarChar, 50).Value = item.isWin;
           

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

            cmd.Parameters.Add("@dateOfMatch", SqlDbType.DateTime).Value = dateofMatch;
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
