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
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnAddTicketTask_Click(object sender, EventArgs e)
        {
             try
            {
                divError.Visible = false;
                string ticketTaskName = txtTicketTaskName.Text;
                string ticketTaskDescription = txtTicketTasksDescription.Text;

                if(Util.addTicketTask(ticketTaskName, ticketTaskDescription)!=0)
                {
                    divSuccessTaskAdded.Visible = true;
                }
            }
            catch(Exception ex)
            {
                divError.Visible = true;
            }
        }
    }
}