using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketingSystemTelekomPMF
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        Util util = new Util();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                try
                {
                    gvAllTicketTypes.DataSource = util.fillDataTableForAllTypes();
                    gvAllTicketTypes.DataBind();
                }
                catch (Exception ex)
                {

                }
            }
            
        }

        protected void gvAllTicketTypes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if(e.CommandName=="cmdTicketTypeDetails")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("TicketTypeDetails.aspx?id="+id);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}