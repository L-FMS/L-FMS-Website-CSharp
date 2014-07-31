using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS.Admin
{
    public partial class AdminPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Admin_Sign_Out(object sender, EventArgs e)
        {
            // 管理员登出
            Session["isAdminLogin"] = "false";

            // 重定向至主页
            Response.Redirect("~/");
        }
    }
}