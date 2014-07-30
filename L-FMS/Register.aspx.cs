using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.Entity.Infrastructure;

namespace L_FMS
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Create_User(object sender, EventArgs e)
        {
            DBModel.GetInstance().RegisterNewUser(Request);

            Response.Redirect("~/");
        }
    }
}