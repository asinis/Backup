using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketingSystemTelekomPMF
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Util util = new Util();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddTicketType_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtTicketTypeName.Text;
                string comment = txtTicketTypeDescription.Text;
                if(util.addTicketType(name, comment)!=0)
                {
                    divSuccessTypeAdded.Visible = true;
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}