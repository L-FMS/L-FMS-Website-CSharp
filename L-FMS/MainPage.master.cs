using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Sign_Out(object sender, EventArgs e)
    {
        // 登出当前用户
        // 更改Session里的值
        Session["userID"] = "-1";
        Session["isLogin"] = "false";
        Session["userName"] = "null";
        Session["isAdminLogin"] = "false";

        // 重定向至主页
        Response.Redirect("~/");
    }
}
