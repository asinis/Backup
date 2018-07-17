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
            if(!Page.IsPostBack)
            {
                falseVisibleForDivsSuccess();
                try
                {
                    int ticketTaskId = Convert.ToInt32(Request.QueryString["id"]);
                    dataInitialize(ticketTaskId);
                }
                catch (Exception ex)
                {
                    divError.Visible = true;
                }
            }
        }
        protected void falseVisibleForDivsSuccess()
        {
            divDeleteStatusForTask.Visible = false;
            divSuccess.Visible = false;
            divUpdateTaskSuccess.Visible = false;
            divNoRowsInGridView.Visible = false;
            divError.Visible = false;
        }
        protected void dataInitialize(int ticketTaskId)
        {
            DataTable dbRowForTicketTaskById = Util.getTicketTaskDetailsById(ticketTaskId);
            txtTicketTaskDetailsName.Text = Convert.ToString(dbRowForTicketTaskById.Rows[0]["Name"]);
            txtTicketTaskDetailsDescription.Text = Convert.ToString(dbRowForTicketTaskById.Rows[0]["Description"]);
            txtTicketTaskDetailsinsertDate.Text = Convert.ToString(dbRowForTicketTaskById.Rows[0]["InsertDate"]);
            chbActive.Checked = Convert.ToBoolean(dbRowForTicketTaskById.Rows[0]["Active"]);

            ddlStatusForTicketTask.DataSource = Util.fillDataTableForDdlTicketTask("GET_VALID_STATUS", ticketTaskId);
            ddlStatusForTicketTask.DataTextField = "Naziv";
            ddlStatusForTicketTask.DataValueField = "Id";
            ddlStatusForTicketTask.DataBind();

            gvTakenStatus.DataSource = Util.fillDataTableForGridViewStatusTask("GET_TAKEN_STATUS_FOR_TASK", ticketTaskId);
            gvTakenStatus.DataBind();

            if (Convert.ToInt32(gvTakenStatus.Rows.Count.ToString()) == 0)
            {
                divNoRowsInGridView.Visible = true;
            }
        }
        protected void btnSaveStatusForTicketTask_Click(object sender, EventArgs e)
        {
             if (Convert.ToInt32(ddlStatusForTicketTask.Items.Count) != 0)
             {
                 falseVisibleForDivsSuccess();
                 int selectedStatusId = Convert.ToInt32(ddlStatusForTicketTask.SelectedItem.Value);
                 int ticketTaskId = Convert.ToInt32(Request.QueryString["id"]);
 
                 if (Util.addStatsuForTask(selectedStatusId, ticketTaskId) == 1)
                 {
                     divSuccess.Visible = true;
                 }
                 dataInitialize(ticketTaskId);
             }
            
        }

        protected void gvTakenStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if(e.CommandName=="cmdDeleteStatusForType")
                {
                    falseVisibleForDivsSuccess();
                    int idStatusTaskCombination = Convert.ToInt32(e.CommandArgument);
                    Util.setInactiveTaskStatusCombination(idStatusTaskCombination);
                    divDeleteStatusForTask.Visible = true;
                    dataInitialize(Convert.ToInt32(Request.QueryString["id"]));
                }
            }
            catch(Exception ex)
            {
                divError.Visible = true;
            }
        }

        protected void btnSaveTicketTaskChanges_Click(object sender, EventArgs e)
        {
            try
            {
                int chk;
                if(chbActive.Checked==true)
                {
                    chk = 1;
                }
                else
                {
                    chk = 0;
                }
                int taskId = Convert.ToInt32(Request.QueryString["id"]);
                string name = txtTicketTaskDetailsName.Text;
                string description = txtTicketTaskDetailsDescription.Text;
                Util.updateTicketTask(taskId, name, description, chk);
                falseVisibleForDivsSuccess();
                divUpdateTaskSuccess.Visible = true;
            }
            catch(Exception ex)
            {
                divError.Visible = true;
            }
        }

    }
}