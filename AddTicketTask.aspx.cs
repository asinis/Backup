using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketingSystemTelekomPMF
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Util util = new Util();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnAddTicketTask_Click(object sender, EventArgs e)
        {
             try
            {
                string ticketTaskName = txtTicketTaskName.Text;
                string ticketTaskDescription = txtTicketTasksDescription.Text;

                util.addTicketTask(ticketTaskName, ticketTaskDescription);
            }
            catch(Exception ex)
            {

            }
        }
    }
}