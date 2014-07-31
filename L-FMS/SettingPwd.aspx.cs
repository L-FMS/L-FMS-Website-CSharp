using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L_FMS
{
    public partial class SettingPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 判断用户是否登录
            if (!Utils.checkLogin(Session))
            {
                // 用户未登录
                // 不允许访问该页面
                // 跳转到登录界面
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void ResetPwd(object sender, EventArgs e)
        {
            // 从表单获取数据
            string oldPwdInput = Request.Form["old-pwd"];
            string newPwd = Request.Form["new-pwd"];
            string confirmPwd = Request.Form["confirm-pwd"];

            // 获取用户ID
            decimal userID = (decimal)Session["userID"];
            // 获取用户密码，从数据库获取，已经过MD5加密
            string oldPwdMD5 = DBModel.GetInstance().GetUserPassword(userID);
            
            // 根据当前时间加密
            string oldPwdInputMD5 = MD5.EncryptMD5WithRule(MD5.Encrypt(oldPwdInput));

            // 判断密码正确性
            if (oldPwdMD5.Equals(oldPwdInputMD5))
            { 
                // 老密码正确
                // 验证新密码两次输入是否一致
                if(newPwd.Equals(confirmPwd))
                {
                    // 两次输入一致
                    // 存入数据库
                    DBModel.GetInstance().ResetUserPassword(userID, newPwd);
                }
                else
                {
                    // 两次输入不一致

                }
            }
            else
            {
                // 老密码不正确

            }
        }
    }
}