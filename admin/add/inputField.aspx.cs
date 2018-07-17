using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketingSystemTelekomPMF.admin.add
{
    public partial class inputField : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divError.Visible = false;

            if (!Page.IsPostBack)
            {
                try
                {
                    ddlTicketTask.DataSource = Util.getAllTicketTasks("GET_ALL_TICKET_TASKS");
                    ddlTicketTask.DataTextField = "Naziv";
                    ddlTicketTask.DataValueField = "Id";
                    ddlTicketTask.DataBind();

                    DataTable dt_el_types = Util.getAllTicketTasks("GET_INPUT_ELEM_TYPES");
                    ddlInputField.DataSource = dt_el_types;
                    ddlInputField.DataTextField = "Name";
                    ddlInputField.DataValueField = "ID";
                    ddlInputField.DataBind();

                    foreach (System.Data.DataRow row in dt_el_types.Rows)
                        ddlInputField.Items.FindByValue(row[0].ToString()).Attributes.Add("data-multi", row[2].ToString());
                    
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            divSuccess.Visible = false;
            divError.Visible = false;

            try
            {
                int task = Int32.Parse(ddlTicketTask.SelectedItem.Value);
                int field = Int32.Parse(ddlInputField.SelectedItem.Value);
                string id = txtID.Text;
                string css = txtCSS.Text;
                string label = txtLabel.Text;
                string pattern = txtPattern.Text;
                string msg = txtValidationMessage.Text;
                string query = txtDataQuery.Text;
                bool req = chkbxReq.Checked;

                string res;

                if (id == "")
                    res = "ID ne moze biti prazan.";
                else
                    res = Util.addInputField(task, field, id, label, css, pattern, msg, query, req);

                if (res == "") {
                    divSuccess.Visible = true;
                } else {
                    errorText.InnerText = res;
                    divError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                errorText.InnerText = ex.Message;
                divError.Visible = true;
            }

        }
    }
}