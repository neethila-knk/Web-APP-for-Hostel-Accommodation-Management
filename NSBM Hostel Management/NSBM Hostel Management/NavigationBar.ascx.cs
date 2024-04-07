using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NSBM_Hostel_Management
{
    public partial class navuc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            // Clear session
            Session.Clear();

            // Redirect to index.aspx
            Response.Redirect("index.aspx");
        }
    }
}