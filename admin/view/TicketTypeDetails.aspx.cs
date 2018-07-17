using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace TicketingSystemTelekomPMF
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                falseDivsSuccess();
                try
                {
                    int ticketTypeId = Convert.ToInt32(Request.QueryString["id"]);
                    dataInitialize(ticketTypeId);
                }
                catch (Exception ex)
                {
                    divError.Visible = true;
                }
            }
            
        }

        protected void falseDivsSuccess()
        {
            divDeleteTaskForType.Visible = false;
            divAddTaskForType.Visible = false;
            divSuccessUpdateType.Visible = false;
            divNoRowsInGridView.Visible = false;
        }
        protected void dataInitialize(int ticketTypeId)
        {
            DataTable dt = Util.getTicketTypeDetailsById(ticketTypeId);
            txtTicketTypeDetailsName.Text = Convert.ToString(dt.Rows[0]["Name"]);
            txtTicketTypeDetailsDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
            txtTicketTypeDetailsinsertDate.Text = Convert.ToString(dt.Rows[0]["InsertDate"]);
            chbActive.Checked = Convert.ToBoolean(dt.Rows[0]["Active"]);

            ddlTasksForType.DataSource = Util.fillDataTableForTypeTaskDdl(Convert.ToInt32(Request.QueryString["id"]));
            ddlTasksForType.DataTextField = "Name";
            ddlTasksForType.DataValueField = "Id";
            ddlTasksForType.DataBind();

            gvTakenTasks.DataSource = Util.fillDataTableForGridViewTypeTask(ticketTypeId);
            gvTakenTasks.DataBind();
            if(Convert.ToInt32(gvTakenTasks.Rows.Count.ToString())==0)
            {
                divNoRowsInGridView.Visible = true;
            }
        }
        protected void btnSaveTicketTypeChanges_Click(object sender, EventArgs e)
        {
            try
            {
                falseDivsSuccess();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int checkedActive;
                if (chbActive.Checked == true)
                {
                    checkedActive = 1;
                }
                else
                {
                    checkedActive = 0;
                }
                string ticketTypeName = txtTicketTypeDetailsName.Text;
                string ticketTypeDescription = txtTicketTypeDetailsDescription.Text;
                if(Util.updateTicketType(id, ticketTypeName, ticketTypeDescription, checkedActive)!=0)
                {
                    divSuccessUpdateType.Visible = true;
                }
            }
            catch(Exception ex)
            {
                divError.Visible = true;
            }
        }
        protected void btnSaveTaskForType_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlTasksForType.Items.Count) != 0)
            {
                try
                {
                    falseDivsSuccess();
                    int selectedTaskId = Convert.ToInt32(ddlTasksForType.SelectedItem.Value);
                    int typeId = Convert.ToInt32(Request.QueryString["id"]);

                    Util.saveTaskForType(typeId, selectedTaskId);

                    dataInitialize(typeId);
                    divAddTaskForType.Visible = true;
                }
                catch (Exception ex)
                {
                    divError.Visible = true;
                }

            }
        }

        protected void gvTakenTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "cmdDeleteTaskForType")
                {
                    falseDivsSuccess();
                    int idTicketTypeTaskCombination = Convert.ToInt32(e.CommandArgument);
                    Util.setInactiveTypeTaskCombination(idTicketTypeTaskCombination);
                    divDeleteTaskForType.Visible = true;
                    dataInitialize(Convert.ToInt32(Request.QueryString["id"]));
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
            }
        }
    }
}