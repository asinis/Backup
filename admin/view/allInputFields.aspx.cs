using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketingSystemTelekomPMF.admin.view
{
    public partial class allInputFields : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    DataTable dt = Util.fetchStoredToDataTable("GET_ALL_INPUT_FIELDS");
                    GridViewAllInputFields.DataSource = dt;
                    GridViewAllInputFields.DataBind();
                }
                catch (Exception ex)
                {
                    divError.InnerText = ex.Message;
                }
            }
        }
    }
}