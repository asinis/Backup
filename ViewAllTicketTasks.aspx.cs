using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TicketingSystemTelekomPMF
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        Util util = new Util();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = util.getAllTicketTasks("GET_ALL_TICKET_TASKS");
                GridViewAllTicketTasks.DataSource = dt;
                GridViewAllTicketTasks.DataBind();
            }
            catch(Exception ex)
            {

            }
        }
    }
}