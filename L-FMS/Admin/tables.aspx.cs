using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS.Admin
{
    public partial class forms : System.Web.UI.Page
    {
        protected ACCOUNT[] users { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            users = DBModel.GetInstance().GetAccountWithSearchString("gmail");
            
        }
    }
}