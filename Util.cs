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
    static class Util
    {
        public static string connString = "Data Source=razvoj3;Initial Catalog=31052018;User id=appPraksaPMF; Password=Csmjer.123;";
        private static SqlConnection conn;

        static Util()
        {
            try
            {
                conn = new SqlConnection(connString);
            }
            catch (Exception e)
            {
                // TODO: what to do when no db connection?
            }
        }

        public static void updateTicketTask(int id, string name, string description, int chk)
        {
            using(SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE_TICKET_TASK", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@taskId",id);
                cmd.Parameters.AddWithValue("@taskName",name);
                cmd.Parameters.AddWithValue("@taskDescription",description);
                cmd.Parameters.Add("@taskActive", chk);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public static void setInactiveTaskStatusCombination(int id)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SET_INACTIVE_TASK_STATUS_COMBINATION", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@taskStatusCombinationId", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void setInactiveTypeTaskCombination(int id)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SET_INACTIVE_TYPE_TASK_COMBINATION", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@typeTaskCombinationId", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static int updateTicketType(int id, string name, string description, int chk)
        {
            int rez;
            SqlCommand cmd = new SqlCommand("UPDATE_TICKET_TYPE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@typeId", id);
            cmd.Parameters.AddWithValue("@typeName", name);
            cmd.Parameters.AddWithValue("@typeDescription", description);
            cmd.Parameters.AddWithValue("@active", chk);

            conn.Open();
            rez = cmd.ExecuteNonQuery();
            conn.Close();
            return rez;
        }
        public static DataTable fillDataTableForAllTypes()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("GET_ALL_TICKET_TYPES", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            
            return dt;
        }
        public static DataTable fillDataTableForGridViewStatusTask(string query, int taskId)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taskId", taskId);

            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            
            return dt;
        }
        public static DataTable fillDataTableForGridViewTypeTask(int typeId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("GET_TAKEN_TASKS_FOR_TYPE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@typeId", typeId);

                con.Open();
                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }

        public static int addStatsuForTask(int statusId, int taskId)
        {
            int rez;
            SqlCommand cmd = new SqlCommand("ADD_STATUS_FOR_TASK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taskId", taskId);
            cmd.Parameters.AddWithValue("@statusId", statusId);

            conn.Open();
            if (cmd.ExecuteNonQuery()>0)
            {
                rez = 1;
            }
            else
            {
                rez=0;
            }
            conn.Close();
         
            return rez;
        }
        public static DataTable fillDataTableForDdlTicketTask(string query, int id)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ticketTaskId", id);

            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            
            return dt;
        }

        public static DataTable getTicketTypeDetailsById(int ticketTypeId)
        {
            DataTable dt = new DataTable();
            
            SqlCommand cmd = new SqlCommand("GET_TICKET_TYPE_INFORMATION_BY_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@typeId ", ticketTypeId);

            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            
            return dt;
        }

        public static DataTable getTicketTaskDetailsById(int ticketTaskId)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand("GET_TICKET_TASK_INFORMATION_BY_ID", conn);
            cmd.Parameters.AddWithValue("@ticketTaskId", ticketTaskId);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            return dt;
        }

        public static int addTicketType(string name, string description)
        {
            int rez;
        
            string query = "ADD_TICKET_TYPE";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);

            conn.Open();
            rez = cmd.ExecuteNonQuery();
            conn.Close();
        
            return rez;
        }
        public static int addStatus(string name,string description)
        {
            int rez;
         
            string query = "ADD_STATUS";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);

            conn.Open();
            rez = cmd.ExecuteNonQuery();
            conn.Close();

            return rez;
        }
        public static int addTicketTask(string name, string description)
        {
            int rez;

            string query = "ADD_TICKET_TASK";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);

            conn.Open();
            rez = cmd.ExecuteNonQuery();
            conn.Close();
        
            return rez;
        }
        
        public static DataTable getAllTicketTasks(string query)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
        
            return dt;
        }

        public static DataTable fillDataTableForTypeTaskDdl(int typeId)
        {
            DataTable dt = new DataTable();
        
            SqlCommand cmd = new SqlCommand("GET_TASKS_FOR_TYPE",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@typeId",typeId);

            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            
            return dt;
        }
        public static int saveTaskForType(int typeId, int taskId)
        {
            int rez;
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("ADD_TASK_FOR_TYPE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@typeId", typeId);
                cmd.Parameters.AddWithValue("@taskId", taskId);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    rez = 1;
                }
                else
                {
                    rez = 0;
                }
            }
            return rez;
        }
        /*public static void insertTicketStatus(int statusId,int ticketTaskId)
        {
            using(SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ADD_TICKET_TASK_STATUS", conn);
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