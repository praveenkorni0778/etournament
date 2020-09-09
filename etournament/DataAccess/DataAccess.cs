using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using etournament.Models;

namespace etournament.Api.DataAccess
{
    public class DataAccess
    {
        string connectionString = ConfigurationManager.AppSettings["DatabaseConnectionString"];
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable Get()
        {
            string queryString = "SELECT * FROM dbo.tbl_tournament;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataAdapter adp = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds.Tables[0];
            }
        }
    }
    public class AppliedAccess
    {
        string connectionString = ConfigurationManager.AppSettings["DatabaseConnectionString"];
        public string Post(AppliedModel obj)
        {
            string msg = "";
            string queryString = "INSERT INTO tbl_quiz values(" + obj.u_id + "," + obj.t_id + ")";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                //SqlDataAdapter adp = new SqlDataAdapter(command);
                try
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                    msg = "Success";
                }
                catch (Exception ex)
                {
                    msg = "Fail" + ex.Message.ToString();
                }

                return msg;
            }
        }
    }
}