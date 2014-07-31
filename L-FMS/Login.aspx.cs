using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void buttonSubmit(object sender, EventArgs e)
        {
            string email = Request.Form["email"];
            string pwd = Request.Form["pwd"];
            string pass = DBModel.GetInstance().GetUserPassword(email);

            if (pass.Equals(""))
            {
                // 用户名非法，无法获取到password
                Session["errorMessage"] = "用户名不存在";
                Session["returnURL"] = "Login.aspx";
                Response.Redirect("Error.aspx");
            }
            else
            {
                string pwd_md5 = MD5.EncryptMD5WithRule(MD5.Encrypt(pwd));
                if (pwd_md5.Equals(pass))
                {
                    // 登录成功
                    Session["userID"] = DBModel.GetInstance().GetUserID(email);
                    Session["isLogin"] = "true";
                    Session["userName"] = DBModel.GetInstance().GetUserName(email);

                    // 获取重定向URL
                    string redirect = Request.Params["redirect"];
                    if (redirect != null)
                    {
                        // 重定向
                        Response.Redirect(redirect);
                    }

                    // 不存在重定向URL
                    // 重定向到主页
                    Response.Redirect("~/");
                }
                else
                {
                    // 密码错误
                    Session["errorMessage"] = "密码错误";
                    Session["returnURL"] = "Login.aspx";
                    Response.Redirect("Error.aspx");
                }
            }
        }
    }
}