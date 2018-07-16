using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace TicketingSystemTelekomPMF
{
    /// <summary>
    /// Summary description for AllStatusForTask
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AllStatusForTask : System.Web.Services.WebService
    {
        public static string connString = "Data Source=razvoj3;Initial Catalog=31052018;User id=appPraksaPMF; Password=Csmjer.123;";

        [WebMethod]
        public void allStatusForTask(int taskId)
        {
            List<Status> listStatus = new List<Status>();
            try
            {
                using(SqlConnection con = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("GET_TAKEN_STATUS_FOR_TASK", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@taskId", taskId);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        Status status = new Status();
                        status.naziv = rdr["Naziv"].ToString();
                        status.opis = rdr["Opis"].ToString();
                        listStatus.Add(status);
                    }
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(listStatus));

            }
            catch(Exception ex)
            {

            }
        }
    }
}
