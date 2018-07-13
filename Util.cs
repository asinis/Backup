using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace TicketingSystemTelekomPMF
{
    public class Util
    {
        public static string connString = "Data Source=razvoj3;Initial Catalog=31052018;User id=appPraksaPMF; Password=Csmjer.123;";
        public void addTicketType(string name, string description)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "ADD_TICKET_TYPE";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {

            }
            
        }
        public void addStatus(string name,string description)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "ADD_STATUS";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void addTicketTask(string name, string description)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "ADD_TICKET_TASK";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@description", description);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }

        }
        public DataTable getAllTicketTasks(string query)
        {
            DataTable dt = new DataTable();

            using(SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }
                catch(Exception ex)
                {
                    //redirect na stranicu greska
                }
            }
            return dt;
        }
    }
}