using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal userID;
            // 查看是否有用户登录
            try
            {
                userID = Decimal.Parse(Session["userID"].ToString());

                // 查看用户权限
                if (Session["isAdminLogin"].Equals("true") || 
                    Utils.checkAdmin(userID))
                {
                    // 管理员已登录
                    // 或
                    // 是管理员权限
                    // 直接设置管理员已登录
                    // 直接跳转
                    Session["isAdminLogin"] = "true";
                    Response.Redirect("~/Admin/Dashboard.aspx");
                }
            }
            catch (NullReferenceException nullEx)
            {
                // 输出错误信息
                System.Diagnostics.Debug.WriteLine(nullEx.Message);

                // 用户未登录
            }
        }

        protected void Admin_Login(object sender, EventArgs e)
        {
            // 获取表单值
            string email = Request.Form["email"];
            string pwd = Request.Form["pwd"];
            string pass = DBModel.GetInstance().GetUserPassword(email);

            if (pass.Equals(""))
            {
                // 用户名非法，无法获取到password
                Session["errorMessage"] = "用户名不存在";
                Session["returnURL"] = "/Admin/Admin.aspx";
                Response.Redirect("~/Error.aspx");
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
                    Response.Redirect("~/Admin/Dashboard.aspx");
                }
                else
                {
                    // 密码错误
                    Session["errorMessage"] = "密码错误";
                    Session["returnURL"] = "~/Admin/Default.aspx";
                    Response.Redirect("Error.aspx");
                }
            }
        }
    }
}