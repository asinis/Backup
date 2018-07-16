using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

namespace TicketingSystemTelekomPMF
{
    public class Util
    {
        public static string connString = "Data Source=razvoj3;Initial Catalog=31052018;User id=appPraksaPMF; Password=Csmjer.123;";

        public int updateTicketType(int id, string name, string description, int chk)
        {
            int rez;
            using(SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_TICKET_TYPE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@typeId", id);
                cmd.Parameters.AddWithValue("@typeName", name);
                cmd.Parameters.AddWithValue("@typeDescription", description);
                cmd.Parameters.AddWithValue("@active", chk);

                con.Open();
                rez = cmd.ExecuteNonQuery();
            }
            return rez;
        }
        public DataTable fillDataTableForAllTypes()
        {
            DataTable dt = new DataTable();
            using(SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("GET_ALL_TICKET_TYPES", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }
        public DataTable fillDataTableForGridViewStatusTask(string query, int taskId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@taskId", taskId);

                con.Open();
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        public int addStatsuForTask(int statusId, int taskId)
        {
            int rez;
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("ADD_STATUS_FOR_TASK", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@taskId", taskId);
                cmd.Parameters.AddWithValue("@statusId", statusId);

                con.Open();
                if (cmd.ExecuteNonQuery()>0)
                {
                    rez = 1;
                }
                else
                {
                    rez=0;
                }
            }
            return rez;
        }
        public DataTable fillDataTableForDdlTicketTask(string query, int id)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ticketTaskId", id);

                con.Open();
                dt.Load(cmd.ExecuteReader());
            }
            
            return dt;
        }

        public DataTable getTicketTypeDetailsById(int ticketTypeId)
        {
            DataTable dt = new DataTable();
            
            using(SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("GET_TICKET_TYPE_INFORMATION_BY_ID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@typeId ", ticketTypeId);

                con.Open();
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        public DataTable getTicketTaskDetailsById(int ticketTaskId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("GET_TICKET_TASK_INFORMATION_BY_ID", conn);
                cmd.Parameters.AddWithValue("@ticketTaskId", ticketTaskId);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }

            return dt;
        }

        public int addTicketType(string name, string description)
        {
            int rez;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "ADD_TICKET_TYPE";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);

                conn.Open();
                rez = cmd.ExecuteNonQuery();
            }
            return rez;
        }
        public int addStatus(string name,string description)
        {
            int rez;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "ADD_STATUS";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);

                conn.Open();
                rez = cmd.ExecuteNonQuery();
            }
            return rez;
        }
        public int addTicketTask(string name, string description)
        {
            int rez;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "ADD_TICKET_TASK";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);

                conn.Open();
                rez = cmd.ExecuteNonQuery();
            }
            return rez;
        }
        public DataTable getAllTicketTasks(string query)
        {
            DataTable dt = new DataTable();

            using(SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }
        public DataTable fillDataTableForTypeTaskDdl(int typeId)
        {
            DataTable dt = new DataTable();
            using(SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("GET_TASKS_FOR_TYPE",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@typeId",typeId);

                con.Open();
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }
        /*public void insertTicketStatus(int statusId,int ticketTaskId)
        {
            using(SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ADD_TICKET_TASK_STATUS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("")
                }
                catch(Exception ex)
                {

                }
            }
        }
          */
    }
}