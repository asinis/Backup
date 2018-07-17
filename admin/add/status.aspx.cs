using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketingSystemTelekomPMF
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddStatus_Click(object sender, EventArgs e)
        {
            try 
            {
                string statusName = txtStatusName.Text;
                string statusDescription = txtStatusDescription.Text;
                if(Util.addStatus(statusName,statusDescription)!=0)
                {
                    divSuccessStatusAdded.Visible = true;
                }
            }
            catch(Exception ex)
            {
                
            }

        }
    }
}