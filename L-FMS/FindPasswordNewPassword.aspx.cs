using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{
    public partial class FindPasswordNewPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Change_Password(object sender, EventArgs e)
        {
            string pwd = Request.Form["pwd"];
            string pwd_validate = Request.Form["pwd-validate"];
            if (! pwd.Equals(pwd_validate))
            {
                Session["errorMessage"] = "密码不一致";
                Session["returnURL"] = "FindPasswordNewPassword.aspx";
                Response.Redirect("Error.aspx");

            } else
            {
                Decimal userid = (Decimal)Session["findPasswordUserId"];
                //Decimal userid = 7;
                DBModel.GetInstance().ResetUserPassword(userid, pwd);
                Session["successMessage"] = "成功啦！！！";
                Session["returnURL"] = "Login.aspx";
                Response.Redirect("Success.aspx");
            }
        }
    }
}