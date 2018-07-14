using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TicketingSystemTelekomPMF
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        Util util = new Util();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                try
                {
                    int ticketTaskId = Convert.ToInt32(Request.QueryString["id"]);
                    DataTable dbRowForTicketTaskById = util.getTicketTaskDetailsById(ticketTaskId);
                    txtTicketTaskDetailsName.Text = Convert.ToString(dbRowForTicketTaskById.Rows[0]["Name"]);
                    txtTicketTaskDetailsDescription.Text = Convert.ToString(dbRowForTicketTaskById.Rows[0]["Description"]);
                    txtTicketTaskDetailsinsertDate.Text = Convert.ToString(dbRowForTicketTaskById.Rows[0]["InsertDate"]);

                    ddlStatusForTicketTask.DataSource = util.fillDataTable("GET_VALID_STATUS",ticketTaskId);
                    ddlStatusForTicketTask.DataTextField = "Naziv";
                    ddlStatusForTicketTask.DataValueField = "Id";
                    ddlStatusForTicketTask.DataBind();
                }
                catch(Exception ex)
                {

                }
            }
        }

        protected void btnSaveStatusForTicketTask_Click(object sender, EventArgs e)
        {
            int selectedStatusId = Convert.ToInt32(ddlStatusForTicketTask.SelectedItem.Value);
            int ticketTaskId = Convert.ToInt32(Request.QueryString["id"]);
            
        }

    }
}