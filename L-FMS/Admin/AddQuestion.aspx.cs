using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS.Admin
{
    public partial class AddQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Create_Question(object sender, EventArgs e)
        {

            DBModel.GetInstance().CreateNewQuestion(Request);
            Response.Redirect("~/");
        }
    }
}