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
                try
                {
                    int ticketTypeId = Convert.ToInt32(Request.QueryString["id"]);
                    dataInitialize(ticketTypeId);
                }
                catch (Exception ex)
                {

                }
            }
            
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
        }
        protected void btnSaveTicketTypeChanges_Click(object sender, EventArgs e)
        {
            try
            {
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

            }
        }
    }
}