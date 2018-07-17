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
        
        protected void Page_Load(object sender, EventArgs e)
        {
                try
                {
                    int ticketTaskId = Convert.ToInt32(Request.QueryString["id"]);
                    DataTable dbRowForTicketTaskById = Util.getTicketTaskDetailsById(ticketTaskId);
                    txtTicketTaskDetailsName.Text = Convert.ToString(dbRowForTicketTaskById.Rows[0]["Name"]);
                    txtTicketTaskDetailsDescription.Text = Convert.ToString(dbRowForTicketTaskById.Rows[0]["Description"]);
                    txtTicketTaskDetailsinsertDate.Text = Convert.ToString(dbRowForTicketTaskById.Rows[0]["InsertDate"]);

                    ddlStatusForTicketTask.DataSource = Util.fillDataTableForDdlTicketTask("GET_VALID_STATUS", ticketTaskId);
                    ddlStatusForTicketTask.DataTextField = "Naziv";
                    ddlStatusForTicketTask.DataValueField = "Id";
                    ddlStatusForTicketTask.DataBind();

                    gvTakenStatus.DataSource = Util.fillDataTableForGridViewStatusTask("GET_TAKEN_STATUS_FOR_TASK", ticketTaskId);
                    gvTakenStatus.DataBind();
                }
                catch(Exception ex)
                {

                }
            
        }

        protected void btnSaveStatusForTicketTask_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(ddlStatusForTicketTask.Items.Count)!=0)
            {
                int selectedStatusId = Convert.ToInt32(ddlStatusForTicketTask.SelectedItem.Value);
                int ticketTaskId = Convert.ToInt32(Request.QueryString["id"]);

                if (Util.addStatsuForTask(selectedStatusId, ticketTaskId) == 1)
                {
                    divSuccess.Visible = true;
                }

                ddlStatusForTicketTask.DataSource = Util.fillDataTableForDdlTicketTask("GET_VALID_STATUS", ticketTaskId);
                ddlStatusForTicketTask.DataTextField = "Naziv";
                ddlStatusForTicketTask.DataValueField = "Id";
                ddlStatusForTicketTask.DataBind();

                gvTakenStatus.DataSource = Util.fillDataTableForGridViewStatusTask("GET_TAKEN_STATUS_FOR_TASK", ticketTaskId);
                gvTakenStatus.DataBind();
            }
        }

    }
}