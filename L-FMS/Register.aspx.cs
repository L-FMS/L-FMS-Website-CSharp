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
            string email = Request.Form["email"];
            string pass = DBModel.GetInstance().GetUserPassword(email);

            if (!pass.Equals(""))
            {
                // 用户名非法，无法获取到password
                Session["errorMessage"] = "该Email已注册过账号";
                Session["returnURL"] = "Register.aspx";
                Response.Redirect("Error.aspx");
            }

            string pwd = Request.Form["pwd"];
            string pwdValidate = Request.Form["pwd-validate"];

            if (!pwd.Equals(pwdValidate))
            {
                // 两次密码输入不一样
                Session["errorMessage"] = "两次密码输入不一致";
                Session["returnURL"] = "Register.aspx";
                Response.Redirect("Error.aspx");
            }

            USER_USERINFO user_userinfo = DBModel.GetInstance().RegisterNewUser(Request);

            // 注册成功
            // Session中保存登录信息
            Session["userID"] = user_userinfo.ACCOUNT;
            Session["isLogin"] = "true";
            Session["userName"] = user_userinfo.USERINFO1.USER_NAME;

            // 重定向
            Response.Redirect("~/");
        }
    }
}