using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using NTNN.ConfigurationHelpers;

namespace NTNN.DAL
{
    public class DataAccess
    {
        // Private Properties
        private static string mConnectionString = "";

        // Public Properties
        public static string ConnectionString
        {
            get 
            {
                if (mConnectionString.Trim() == "")
                {
                    mConnectionString = DataAccessConfiguration.DataAccessSection.ConnectionString;
                }
                return mConnectionString; 
            }
            set { mConnectionString = value; }
        }

        // Constructor
        public DataAccess() { }
                
        // Methods
        public static int ExecuteNonQuery(DbCommand cmd)
        {
            int ret;
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                cmd.Connection = cn;
                ret = cmd.ExecuteNonQuery();
            }
            return ret;
        }

        public static IDataReader ExecuteReader(DbCommand cmd)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            cn.Open();
            cmd.Connection = cn;
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public static IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            SqlConnection cn = new SqlConnection(ConnectionString);
            cn.Open();
            cmd.Connection = cn;
            return cmd.ExecuteReader(behavior);
        }

        public static object ExecuteScalar(DbCommand cmd)
        {
            object ret;
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                cmd.Connection = cn;
                ret = cmd.ExecuteScalar();
            }
            return ret;
        }
    }
}
