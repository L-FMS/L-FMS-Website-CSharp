using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{
    public partial class error : System.Web.UI.Page
    {
        protected string errorMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            errorMessage = Session["errorMessage"].ToString();
        }

        protected void goBack(object sender, EventArgs e)
        {
            if (Session["returnURL"].ToString() != null)
                Response.Redirect(Session["returnURL"].ToString());
            else
                Response.Redirect("Default.aspx");
        }
    }
}